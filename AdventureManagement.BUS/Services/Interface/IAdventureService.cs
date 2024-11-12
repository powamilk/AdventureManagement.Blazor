using AdventureManagement.BUS.ViewModel.AdventureViewModel;
using AdventureManagement.BUS.ViewModel.GuideViewModel;
using AdventureManagement.BUS.ViewModel.OrganismViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureManagement.BUS.Services.Interface
{
    public interface IAdventureService
    {
        Task<List<AdventureVM>> GetAllAsync();
        Task<AdventureVM> GetByIdAsync(int id);
        Task CreateAsync(CreateAdventureVM vm);
        Task UpdateAsync(int id, UpdateAdventureVM vm);
        Task DeleteAsync(int id);
        Task<List<OrganismVM>> GetAllOrganismsAsync();
        Task<List<GuideVM>> GetAllGuidesAsync();

    }
}
