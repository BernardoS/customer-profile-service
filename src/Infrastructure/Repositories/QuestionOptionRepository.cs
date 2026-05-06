using CustomerProfileService.Domain.Interfaces;

public class QuestionOptionRepository : IQuestionOptionRepository
{
    private readonly AppDbContext _context;

    public QuestionOptionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<QuestionOption> AddAsync(QuestionOption option)
    {
        await _context.QuestionOptions.AddAsync(option);
        await _context.SaveChangesAsync();

        return option;
    }

    public Task UpdateAsync(QuestionOption question)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(QuestionOption question)
    {
        throw new NotImplementedException();
    }

    public async Task<QuestionOption?> GetAsync(Guid id)
    {
        var questionOption = await _context.QuestionOptions.FindAsync(id);
        
        return questionOption ?? null;
    }

    public Task<QuestionOption> GetByQuestion(Guid questionId)
    {
        throw new NotImplementedException();
    }
}