using FluentValidation;

namespace CustomerProfileService.Api.Validators;

public class CreateCustomerValidator : AbstractValidator<CreateCustomerRequest>
{
    public CreateCustomerValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome é obrigatório")
            .MinimumLength(3).WithMessage("Nome deve ter pelo menos 3 caracteres");

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress().WithMessage("Email inválido");

        RuleFor(x => x.BirthDate)
            .LessThan(DateTime.Now.AddYears(-18))
            .WithMessage("Data de nascimento inválida"); ;
    }
}