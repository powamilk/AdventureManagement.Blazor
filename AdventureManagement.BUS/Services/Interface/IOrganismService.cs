using AdventureManagement.BUS.ViewModel.OrganismViewModel;

namespace AdventureManagement.BUS.Services.Interface
{
    public interface IOrganismService
    {
        Task<List<OrganismVM>> GetAllOrganismsAsync();
        Task<OrganismVM> GetOrganismByIdAsync(int id);
        Task CreateOrganismAsync(CreateOrganismVM model);
        Task UpdateOrganismAsync(int id, UpdateOrganismVM model);
        Task DeleteOrganismAsync(int id);
    }

}
