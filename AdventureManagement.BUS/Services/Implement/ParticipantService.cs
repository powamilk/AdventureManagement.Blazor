﻿using AdventureManagement.DAL.Entities;
using AdventureManagement.BUS.ViewModel.Participant;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using AdventureManagement.BUS.Services.Interface;
using AdventureManagement.DAL;

namespace AdventureManagement.BUS.Services.Implement
{
    public class ParticipantService : IParticipantService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ParticipantService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Create(ParticipantCreateVM model)
        {
            if (await _context.Participants.AnyAsync(p => p.Email == model.Email))
            {
                return false;
            }
            var participant = new Participant
            {
                Name = model.Name,
                Email = model.Email,
                CreatedAt = DateTime.Now
            };
            await _context.Participants.AddAsync(participant);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var participant = await _context.Participants.FindAsync(id);
            if (participant == null)
            {
                return false;
            }
            _context.Participants.Remove(participant);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ParticipantVM>> GetAll()
        {
            var participant = await _context.Participants
                                .Include(p => p.ParticipantInteractions)
                                .Select(p => new ParticipantVM
                                {
                                    Id = p.Id,
                                    Name = p.Name,
                                    Email = p.Email,
                                    CreatedAt = p.CreatedAt,
                                    AdventureCount = p.ParticipantInteractions.Count()
                                }
                                ).ToListAsync();
            return participant;
        }

        public async Task<ParticipantVM> GetById(int id)
        {
            var participant = await _context.Participants
                    .Include(p => p.ParticipantInteractions)
                    .FirstOrDefaultAsync(p => p.Id == id);
            if (participant == null)
            {
                return null;
            }
            var participantVM = _mapper.Map<ParticipantVM>(participant);
            participantVM.AdventureCount = participant.ParticipantInteractions.Count();
            return participantVM;
        }

        public async Task<bool> Update(int id, ParticipantUpdateVM model)
        {
            var participant = await _context.Participants.FindAsync(id);
            if (participant == null)
            {
                return false;
            }
            participant.Name = model.Name;
            participant.Email = model.Email;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
