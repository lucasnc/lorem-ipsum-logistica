using LoremIpsum.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoremIpsum.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        Task<ClienteDto?> Get(int id);
        Task<IEnumerable<ClienteDto>> GetAll();
        Task<ClienteDto> Post(ClienteDtoCreate cliente);
        Task<ClienteDto> Put(ClienteDtoUpdate cliente);
        Task<bool> Delete(int id);
    }
}
