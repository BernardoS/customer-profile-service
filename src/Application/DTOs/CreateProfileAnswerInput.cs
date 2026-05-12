namespace CustomerProfileService.Application.DTOs;

public class CreateProfileAnswerInput
{
    public Guid QuestionId { get; set; }
    public Guid AnswerId { get; set; }
}