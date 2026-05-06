using FluentValidation;

namespace CustomerProfileService.Api.Validators;

public class CreateProfileAnswerValidator : AbstractValidator<CreateProfileAnswerRequest>
{
    public CreateProfileAnswerValidator()
    {
        RuleFor(x => x.QuestionId)
            .NotEmpty()
            .WithMessage("QuestionId é obrigatório");

        RuleFor(x => x.AnswerId)
            .NotEmpty()
            .WithMessage("AnswerId é obrigatório");
    }
}