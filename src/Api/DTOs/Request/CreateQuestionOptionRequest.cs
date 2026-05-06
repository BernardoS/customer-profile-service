using CustomerProfileService.Application.DTOs;

namespace CustomerProfileService.Api.DTOs.Request;

public class CreateQuestionOptionRequest
{
    public string Description { get; set; }
    public int Score { get; set; }

    public CreateQuestionOptionInput MapToQuestionOptionInput()
    {
        return new CreateQuestionOptionInput
        {
            Description = Description,
            Score = Score,
        };
    }
}