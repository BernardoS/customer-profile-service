using CustomerProfileService.Application.DTOs;

public class CreateProfileRequest
{
    public Guid CustomerId { get; set; }
    public Guid FormId { get; set; }
    public List<CreateProfileAnswerRequest> Answers { get; set; } = new();

    public CreateProfileInput MapToInput()
    {
        var answerList = new List<CreateProfileAnswerInput>();
        
        foreach (var answer in Answers)
        {
            answerList.Add(new CreateProfileAnswerInput()
            {
                AnswerId = answer.AnswerId,
                QuestionId = answer.QuestionId,
            });
        }

        return new CreateProfileInput
        {
            FormId = FormId,
            CustomerId = CustomerId,
            Answers = answerList
        };
    }
}