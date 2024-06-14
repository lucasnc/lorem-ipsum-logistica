using LoremIpsum.Data.Context;
using LoremIpsum.Data.Entities;
using LoremIpsum.Domain.Exceptions;
using LoremIpsum.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace LoremIpsum.Data.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private DbSet<Cliente> _dataset;

        public ClienteRepository(LoremIpsumContext context) : base(context)
        {
            _dataset = context.Set<Cliente>();
        }

        public async Task<List<Cliente>> GetAll()
        {
            return await _dataset.Include(c => c.Enderecos).AsNoTracking().ToListAsync();
        }
        public async Task<Cliente?> GetById(int Id)
        {
            return await _dataset
                .Include(c => c.Enderecos)
                .Where(c => c.Id.Equals(Id))
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Cliente> UpdateAsync(Cliente item)
        {
            var result = await _context.Cliente.Include(c => c.Enderecos).FirstOrDefaultAsync(p => p.Id.Equals(item.Id));

            if (result == null)
                throw new BadRequestException("Cliente não encontrado.");

            _context.Entry(result).CurrentValues.SetValues(item);
            _context.RemoveRange(result.Enderecos);
            foreach (var endereco in item.Enderecos)
            {
                endereco.ClienteId = item.Id;
                _context.Endereco.Add(endereco);
            }

            await _context.SaveChangesAsync();

            return result;
        }
    }
}
