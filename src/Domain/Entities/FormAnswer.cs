public class FormAnswer
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public Question AnsweredQuestion {get; private set;}
    public QuestionOption AnsweredQuestionOption {get; private set;}
    public QuestionForm AnsweredForm {get;private set;}
    public Customer Customer {get; private set;}
}