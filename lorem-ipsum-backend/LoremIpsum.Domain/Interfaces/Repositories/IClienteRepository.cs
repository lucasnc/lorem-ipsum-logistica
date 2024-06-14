using LoremIpsum.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoremIpsum.Domain.Interfaces.Repositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<List<Cliente>> GetAll();
        Task<Cliente?> GetById(int Id);
    }
}
