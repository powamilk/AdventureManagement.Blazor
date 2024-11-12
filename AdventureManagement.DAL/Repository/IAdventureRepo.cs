
using AdventureManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureManagement.DAL.Repository
{
    public interface IAdventureRepo
    {
        Task<List<Adventure>> GetAll();
        Task<Adventure> GetById(int id);
        Task<bool> Create(Adventure entity);
        Task<bool> Update(Adventure entity);
        Task<bool> Delete(int id);
    }
}
