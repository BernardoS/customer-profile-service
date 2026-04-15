using CustomerProfileService.Domain.Interfaces;

public class Question
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public List<QuestionOption> Options { get; private set; } = new();
    public Guid QuestionFormId { get; private set; }
    
    public Question(){}

    public Question(Guid FormId, string Title)
    {
        this.Id = Guid.NewGuid();
        this.QuestionFormId = FormId;
        this.Title = Title;
        this.CreatedAt = DateTime.Now;
        this.UpdatedAt = DateTime.Now;
    }
    
}