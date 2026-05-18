namespace CustomerProfileService.Application.DTOs;
public class CreateProfileInput
{
    public Guid CustomerId { get; set; }
    public Guid FormId { get; set; }
    public List<CreateProfileAnswerInput> Answers { get; set; }
}