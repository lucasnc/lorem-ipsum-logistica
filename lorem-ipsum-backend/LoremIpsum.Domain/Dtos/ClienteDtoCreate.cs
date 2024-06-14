using LoremIpsum.Domain.Enums;

namespace LoremIpsum.Domain.Dtos
{
    public class ClienteDtoCreate
    {
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public TipoGenero Genero { get; set; }
        public List<EnderecoDtoCreate> Enderecos { get; set; } = new List<EnderecoDtoCreate>();
    }
}
