using LoremIpsum.Data.Context;
using LoremIpsum.Domain.Entities;
using LoremIpsum.Domain.Exceptions;
using LoremIpsum.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoremIpsum.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly LoremIpsumContext _context;
        private DbSet<T> _dataset;
        public BaseRepository(LoremIpsumContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));

            if (result == null)
                throw new BadRequestException("Cliente não encontrado.");

            _dataset.Remove(result);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _dataset.AnyAsync(p => p.Id.Equals(id));
        }

        public async Task<T> InsertAsync(T item)
        {
            _dataset.Add(item);

            await _context.SaveChangesAsync();
            
            return item;
        }

        public async Task<T> SelectAsync(int id)
        {
            return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            return await _dataset.ToListAsync();
        }

        public async Task<T> UpdateAsync(T item)
        {
            var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));

            if (result == null)
                throw new BadRequestException("Cliente não encontrado.");

            _context.Entry(result).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();


            return item;
        }
    }
}
