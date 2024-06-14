using AutoMapper;
using LoremIpsum.Data.Entities;
using LoremIpsum.Domain.Dtos;
using LoremIpsum.Domain.Interfaces;
using LoremIpsum.Domain.Interfaces.Repositories;
using LoremIpsum.Domain.Interfaces.Services;

namespace LoremIpsum.Service.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;
        public ClienteService(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ClienteDto?> Get(int id)
        {
            var entity = await _repository.GetById(id);
            return _mapper.Map<ClienteDto>(entity);
        }

        public async Task<IEnumerable<ClienteDto>> GetAll()
        {
            var listEntity = await _repository.GetAll();
            return _mapper.Map<IEnumerable<ClienteDto>>(listEntity);
        }

        public async Task<ClienteDto> Post(ClienteDtoCreate user)
        {
            var entity = _mapper.Map<Cliente>(user);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<ClienteDto>(result);
        }

        public async Task<ClienteDto> Put(ClienteDtoUpdate user)
        {
            var entity = _mapper.Map<Cliente>(user);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<ClienteDto>(result);
        }
    }
}
