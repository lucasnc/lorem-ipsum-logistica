using FluentValidation;
using LoremIpsum.Domain.Dtos;

namespace lorem_ipsum_api.Validators
{
    public class ClienteCreateValidator : AbstractValidator<ClienteDtoCreate>
    {
        public ClienteCreateValidator()
        {
            RuleFor(c => c.Nome)
              .NotEmpty()
              .NotNull()
              .MaximumLength(50);

            RuleFor(c => c.DataNascimento)
              .NotEmpty()
              .NotNull();

            RuleFor(c => c.Genero)
              .IsInEnum();

            RuleForEach(c => c.Enderecos)
                .SetValidator(new EnderecoCreateValidator());
        }
    }
}
