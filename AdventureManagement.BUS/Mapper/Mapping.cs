using AdventureManagement.BUS.ViewModel.AdventureViewModel;
using AdventureManagement.BUS.ViewModel.GuideViewModel;
using AdventureManagement.BUS.ViewModel.OrganismViewModel;
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
            CreateMap<CreateAdventureVM, Adventure>().ReverseMap();
            CreateMap<UpdateAdventureVM, Adventure>().ReverseMap();
            CreateMap<AdventureVM, Adventure>().ReverseMap();
            CreateMap<Guide, GuideVM>();

            // Mapping cho Organism và OrganismVM
            CreateMap<Organism, OrganismVM>();
        }
    }
}
