using LoremIpsum.Data.Entities;
using LoremIpsum.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoremIpsum.Service.Test
{
    public class ClienteTestes
    {
        public ClienteDtoCreate clienteDtoCreate;
        public EnderecoDtoCreate enderecoDtoCreate;

        public ClienteDto cliente;
        public EnderecoDto endereco;

        public ClienteDto clienteDtoResult;
        public EnderecoDto enderecoDtoResult;
        public int clienteId;
        public ClienteTestes()
        {
            clienteId = 1;

            endereco = new EnderecoDto()
            {
                Cep = "01001000",
                Logradouro = Faker.Address.StreetAddress(),
                Localidade = Faker.Address.City(),
                Bairro = Faker.Address.SecondaryAddress(),
                Numero = Faker.RandomNumber.Next(0, 50).ToString(),
                TipoEndereco = (Domain.Enums.TipoEndereco)Faker.RandomNumber.Next(0, 1),
                Uf = "SP",
                Complemento = Faker.Address.StreetAddress(),
            };

            cliente = new ClienteDto()
            {
                Id = 1,
                Nome = Faker.Name.FullName(),
                DataNascimento = Faker.DateOfBirth.Next().Date,
                Genero = (Domain.Enums.TipoGenero)Faker.RandomNumber.Next(0, 1),
                Enderecos = new List<EnderecoDto> { endereco },
            };

            enderecoDtoCreate = new EnderecoDtoCreate()
            {
                Cep = "01001000",
                Logradouro = Faker.Address.StreetAddress(),
                Localidade = Faker.Address.City(),
                Bairro = Faker.Address.SecondaryAddress(),
                Numero = Faker.RandomNumber.Next(0, 50).ToString(),
                TipoEndereco = (Domain.Enums.TipoEndereco)Faker.RandomNumber.Next(0, 1),
                Uf = "SP",
                Complemento = Faker.Address.StreetAddress(),
            };

            clienteDtoCreate = new ClienteDtoCreate()
            {
                Nome = Faker.Name.FullName(),
                DataNascimento = Faker.DateOfBirth.Next().Date,
                Genero = (Domain.Enums.TipoGenero)Faker.RandomNumber.Next(0, 1),
                Enderecos = new List<EnderecoDtoCreate> { enderecoDtoCreate },
            };

            clienteDtoResult = new ClienteDto()
            {
                Id = 1,
                Nome = clienteDtoCreate.Nome,
                DataNascimento = clienteDtoCreate.DataNascimento,
                Genero = clienteDtoCreate.Genero,
                Enderecos = new List<EnderecoDto> () { new EnderecoDto()
                {
                    Cep = enderecoDtoCreate.Cep,
                    Logradouro = enderecoDtoCreate.Logradouro,
                    Localidade = enderecoDtoCreate.Localidade,
                    Bairro = enderecoDtoCreate.Bairro,
                    Numero = enderecoDtoCreate.Numero,
                    TipoEndereco = enderecoDtoCreate.TipoEndereco,
                    Uf = enderecoDtoCreate.Uf,
                    Complemento = enderecoDtoCreate.Complemento,
                } },
            };

        }
    }
}
