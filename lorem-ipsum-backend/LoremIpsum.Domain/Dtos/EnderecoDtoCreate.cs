using LoremIpsum.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoremIpsum.Domain.Dtos
{
    public class EnderecoDtoCreate
    {
        public TipoEndereco TipoEndereco { get; set; }
        public string Cep { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Localidade { get; set; } = string.Empty;
        public string Uf { get; set; } = string.Empty;
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
    }
}
