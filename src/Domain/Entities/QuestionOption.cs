public class QuestionOption
{
    public Guid Id { get; private set; }
    public string Description { get; private set; }
    public int Score { get; private set; }
    public Guid QuestionId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
}