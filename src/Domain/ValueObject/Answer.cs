public class Answer
{
    public Guid QuestionId {get; private set;}

    public Guid OptionId {get; private set;}

    public Answer(Guid questionId,Guid optionId)
    {
        QuestionId = questionId;
        OptionId = optionId;
    }
}