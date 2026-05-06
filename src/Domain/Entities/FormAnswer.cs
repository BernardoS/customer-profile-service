public class FormAnswer
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public Guid AnsweredQuestionId {get; private set;}
    public Guid AnsweredQuestionOptionId {get; private set;}
    public Guid AnsweredFormId {get;private set;}
    public Guid CustomerId {get; private set;}

    public FormAnswer()
    {
    }
    
    public FormAnswer(Guid customerId,Guid FormId, Guid QuestionId, Guid QuestionOptionId)
    {
        Id = Guid.NewGuid();
        
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}