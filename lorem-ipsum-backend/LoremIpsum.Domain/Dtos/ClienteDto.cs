using LoremIpsum.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoremIpsum.Domain.Dtos
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public TipoGenero Genero { get; set; }
        public List<EnderecoDto> Enderecos { get; set; } = new List<EnderecoDto>();
    }
}
