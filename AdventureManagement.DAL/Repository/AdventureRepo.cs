
using AdventureManagement.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureManagement.DAL.Repository
{
    public class AdventureRepo : IAdventureRepo
    {
        private readonly AppDbContext _appDbContext;

        public AdventureRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> Create(Adventure entity)
        {
            _appDbContext.Adventures.Add(entity);
            return await _appDbContext.SaveChangesAsync() > 0;  
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _appDbContext.Adventures.FindAsync(id);
            if (response == null) return false;
            _appDbContext.Adventures.Remove(response);
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public async Task<List<Adventure>> GetAll()
        {
            return await _appDbContext.Adventures.ToListAsync();
        }

        public async Task<Adventure> GetById(int id)
        {
            return await _appDbContext.Adventures.FindAsync(id);
        }

        public async Task<bool> Update(Adventure entity)
        {
            _appDbContext.Adventures.Update(entity);
            return await _appDbContext.SaveChangesAsync() > 0;
        }
    }
}
