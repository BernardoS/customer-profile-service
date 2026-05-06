using FluentValidation;

namespace CustomerProfileService.Api.Validators;

public class CreateProfileValidator : AbstractValidator<CreateProfileRequest>
{
    public CreateProfileValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotNull().WithMessage("Id do usuário é obrigatório");
        
        RuleFor(x => x.FormId)
            .NotNull().WithMessage("Id do formulário é obrigatório");

        RuleFor(x => x.Answers)
            .NotEmpty()
            .WithMessage("É necessário responder ao menos uma pergunta");

        RuleForEach(x => x.Answers)
            .SetValidator(new CreateProfileAnswerValidator());
    }
}