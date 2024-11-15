using AdventureManagement.BUS.ViewModel.AdventureViewModel;
using AdventureManagement.BUS.ViewModel.GuideViewModel;
using AdventureManagement.BUS.ViewModel.OrganismViewModel;
using AdventureManagement.BUS.ViewModel.Participant;
using AdventureManagement.BUS.ViewModel.ParticipantInteraction;
using AdventureManagement.DAL.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureManagement.BUS.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            // Adventure mappings
            CreateMap<CreateAdventureVM, Adventure>().ReverseMap();
            CreateMap<UpdateAdventureVM, Adventure>().ReverseMap();
            CreateMap<AdventureVM, Adventure>().ReverseMap();

            // Guide mappings
            CreateMap<CreateGuideVM, Guide>().ReverseMap();
            CreateMap<UpdateGuideVM, Guide>().ReverseMap();
            CreateMap<GuideVM, Guide>().ReverseMap();

            // Organism mappings
            CreateMap<CreateOrganismVM, Organism>().ReverseMap();
            CreateMap<UpdateOrganismVM, Organism>().ReverseMap();
            CreateMap<OrganismVM, Organism>().ReverseMap();

            // Participant mappings
            CreateMap<ParticipantCreateVM, Participant>().ReverseMap();
            CreateMap<ParticipantUpdateVM, Participant>().ReverseMap();
            CreateMap<ParticipantVM, Participant>().ReverseMap();

            // ParticipantInteraction mappings
            CreateMap<CreateParticipantInteractionVM, ParticipantInteraction>().ReverseMap();
            CreateMap<UpdateParticipantInteractionVM, ParticipantInteraction>().ReverseMap();
            CreateMap<ParticipantInteractionVM, ParticipantInteraction>().ReverseMap();
        }
    }
}
