using CustomerProfileService.Api.DTOs.Request;
using CustomerProfileService.Application.DTOs;

public class CreateQuestionRequest
{
    public Guid FormId { get; set; }
    public string QuestionTitle { get; set; }

    public List<CreateQuestionOptionRequest?> QuestionOptions { get; set; }

    public CreateQuestionInput MapToQuestionInput()
    {
        var optionList = new List<CreateQuestionOptionInput>();

        if (QuestionOptions != null && QuestionOptions.Any())
        {
            foreach (var option in QuestionOptions)
            {
                optionList.Add(option.MapToQuestionOptionInput());
            }
        }
        return new CreateQuestionInput
        {
            FormId = FormId,
            QuestionTitle = QuestionTitle,
            QuestionOptions = optionList
        };
    }
}