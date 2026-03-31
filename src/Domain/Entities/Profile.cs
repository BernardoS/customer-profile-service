public class Profile
{
    public Guid ProfileId{get; private set;}
    public int Score{get;private set;}

    public InvestorType Type {get;private set;}

    public Profile(int score)
    {
        Score = score;
        Type = CalculateType(score);
    }

    private InvestorType CalculateType(int score)
    {
        if (score <= 3) return InvestorType.Conservative;
        if (score <= 7) return InvestorType.Moderate;
        return InvestorType.Aggressive;
    }
}