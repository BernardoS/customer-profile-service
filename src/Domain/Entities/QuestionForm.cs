public class QuestionForm{
    public Guid Id {get; private set;}
    public DateTime CreatedAt {get;private set;}
    public DateTime UpdatedAt {get;private set;}
    public List<Question> Questions {get; private set;}

    public QuestionForm()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}