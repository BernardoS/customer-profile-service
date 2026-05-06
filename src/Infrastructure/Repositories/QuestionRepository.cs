using CustomerProfileService.Domain.Interfaces;

public class QuestionRepository : IQuestionRepository
{
    private readonly AppDbContext _context;

    public QuestionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Question> AddAsync(Question question)
    {
        await _context.Questions.AddAsync(question);
        await _context.SaveChangesAsync();

        return question;
    }

    public Task UpdateAsync(Question question)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(Question question)
    {
        throw new NotImplementedException();
    }

    public async Task<Question?> GetAsync(Guid id)
    {
        var question = await _context.Questions.FindAsync(id);

        return question;
    }

    public Task<Question> GetByFormAsync(Guid formId)
    {
        throw new NotImplementedException();
    }
}