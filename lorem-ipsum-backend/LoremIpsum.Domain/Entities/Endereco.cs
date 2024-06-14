using LoremIpsum.Domain.Entities;
using LoremIpsum.Domain.Enums;

namespace LoremIpsum.Data.Entities
{
    public class Endereco : BaseEntity
    {
        public TipoEndereco TipoEndereco { get; set; }
        public string Cep { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Localidade { get; set; } = string.Empty;
        public string Uf { get; set; } = string.Empty;
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
