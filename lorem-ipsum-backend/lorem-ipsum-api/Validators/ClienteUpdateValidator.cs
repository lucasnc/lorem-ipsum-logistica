using FluentValidation;
using LoremIpsum.Domain.Dtos;

namespace lorem_ipsum_api.Validators
{
    public class ClienteUpdateValidator : AbstractValidator<ClienteDtoUpdate>
    {
        public ClienteUpdateValidator()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0);

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
                .SetValidator(new EnderecoUpdateValidator());
        }
    }
}
