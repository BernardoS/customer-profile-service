public class Profile
{
    public Guid ProfileId { get; private set; }
    public int Score { get; private set; }
    public InvestorType Type { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public Profile(){}
    public Profile(int score, int maxScore)
    {
        ProfileId = new Guid();
        Score = score;
        Type = CalculateType(score, maxScore);
    }

    private InvestorType CalculateType(int score, int maxScore)
    {
        int conservativeScoreLimit = (int)maxScore / 3;
        int moderateScoreLimit = (int)(maxScore / 3) * 2;

        if (score <= conservativeScoreLimit) return InvestorType.Conservative;
        if (score <= moderateScoreLimit) return InvestorType.Moderate;
        return InvestorType.Aggressive;
    }


}