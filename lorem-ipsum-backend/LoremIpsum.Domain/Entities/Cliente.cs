using LoremIpsum.Domain.Entities;
using LoremIpsum.Domain.Enums;

namespace LoremIpsum.Data.Entities
{
    public class Cliente : BaseEntity
    {
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public TipoGenero Genero { get; set; }
        public List<Endereco> Enderecos { get; set; }
    }
}
