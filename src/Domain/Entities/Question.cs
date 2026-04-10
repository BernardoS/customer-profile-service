public class Question
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public List<QuestionOption> Options { get; private set; } = new();
}