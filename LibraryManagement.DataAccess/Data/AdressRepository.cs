using LibraryManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DataAccess.Data
{
    public class AdressRepository : IGenericRepository<Adress>
    {
        private readonly LibraryDbContext _context;

        public AdressRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public Adress Create(Adress adress)
        {
            if (adress is not null)
            {
                _context.Adresses.Add(adress);
                _context.SaveChanges();
                return adress;
            }
            return adress;

        }

        public async Task<bool> Delete(int id)
        {
            var adress = await _context.Adresses.FirstOrDefaultAsync(adress => adress.Id == id);
            if (adress != null)
            {
                _context.Adresses.Remove(adress);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<List<Adress>> GetAll()
        {
            return await Task.FromResult(_context.Adresses.ToList());
        }

        public async Task<Adress> Get(int id)
        {
            var adress = await _context.Adresses.FindAsync(id);
            return adress;
        }

        public async Task<Adress> Update(Adress adress)
        {
            var existAdress = _context.Adresses.Attach(adress);
            existAdress.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return adress;
        }


    }
}
