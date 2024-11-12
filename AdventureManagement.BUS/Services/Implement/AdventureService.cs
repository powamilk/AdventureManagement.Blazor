using AdventureManagement.BUS.ViewModel.AdventureViewModel;
using AdventureManagement.DAL;
using AdventureManagement.BUS.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AdventureManagement.DAL.Repository;
using AdventureManagement.DAL.Entities;
using AdventureManagement.BUS.ViewModel.OrganismViewModel;
using AdventureManagement.BUS.ViewModel.GuideViewModel;
using AdventureManagement.BUS.Services.Interface;

namespace AdventureManagement.BUS.Services.Implement
{
    public class AdventureService : IAdventureService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AdventureService(IMapper mapper)
        {
            _context = new();
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateAdventureVM vm)
        {
            var adventure = new Adventure
            {
                Title = vm.Title,
                Description = vm.Description,
                Location = vm.Location,
                Duration = vm.Duration,
                GuideId = vm.GuideId,
                AdventureOrganisms = vm.OrganismIds.Select(id => new AdventureOrganism { OrganismId = id }).ToList()
            };
            _context.Adventures.Add(adventure);
            await _context.SaveChangesAsync();

        }

        public async Task<List<GuideVM>> GetAllGuidesAsync()
        {
            var guides = _context.Guides.ToListAsync();
            return _mapper.Map<List<GuideVM>>(guides);
        }


        public async Task DeleteAsync(int id)
        {
            var response = await _context.Adventures.FindAsync(id);
            if (response != null)
            {
                _context.Adventures.Remove(response);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<AdventureVM>> GetAllAsync()
        {
            var response = _context.Adventures.ToList();
            return _mapper.Map<List<AdventureVM>>(response);
        }

        public async Task<AdventureVM> GetByIdAsync(int id)
        {
            var response = await _context.Adventures.Include(a => a.Guide).Include(a => a.ParticipantInteractions).Include(a => a.AdventureOrganisms)
               .ThenInclude(a => a.Organism).FirstOrDefaultAsync(a => a.Id == id);

            if (response == null) return null;

            return _mapper.Map<AdventureVM>(response);
        }
        public async Task<List<OrganismVM>> GetAllOrganismsAsync()
        {
            var organisms = await _context.Organisms.ToListAsync();
            return _mapper.Map<List<OrganismVM>>(organisms);
        }


        public async Task UpdateAsync(int id, UpdateAdventureVM vm)
        {
            var response = await _context.Adventures.Include(a => a.AdventureOrganisms).FirstOrDefaultAsync(a => a.Id == id);

            if (response == null) return;

            response.Title = vm.Title;
            response.Description = vm.Description;
            response.Location = vm.Location;
            response.Duration = vm.Duration;
            response.GuideId = vm.GuideId;

            response.AdventureOrganisms.Clear();
            response.AdventureOrganisms = vm.OrganismIds.Select(id => new AdventureOrganism { OrganismId = id }).ToList();

            await _context.SaveChangesAsync();
        }
    }
}
