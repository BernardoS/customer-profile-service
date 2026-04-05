public class CreateProfileRequest
{
    public Guid CustomerId { get; set; }
    public List<CreateProfileAnswerRequest> Answers { get; set; } = new();
}