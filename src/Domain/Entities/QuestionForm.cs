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

    public int GetMaxScore()
    {
      int maxScore = 0;

      maxScore = Questions.Sum(q => q.GetMaxScore());
      
      return maxScore;
    }
}