using FluentValidation;
using LoremIpsum.Domain.Dtos;

namespace lorem_ipsum_api.Validators
{
    public class EnderecoUpdateValidator : AbstractValidator<EnderecoDtoUpdate>
    {
        public EnderecoUpdateValidator()
        {

            RuleFor(c => c.Cep)
              .NotEmpty()
              .NotNull()
              .MaximumLength(9);

            RuleFor(c => c.Logradouro)
              .NotEmpty()
              .NotNull()
              .MaximumLength(50);

            RuleFor(c => c.Numero)
              .NotEmpty()
              .NotNull()
              .MaximumLength(50);

            RuleFor(c => c.Localidade)
              .NotEmpty()
              .NotNull()
              .MaximumLength(50);

            RuleFor(c => c.Uf)
              .NotEmpty()
              .NotNull()
              .MaximumLength(2);

            RuleFor(c => c.Complemento)
              .MaximumLength(50);

            RuleFor(c => c.Bairro)
              .MaximumLength(50);
        }
    }
}
