using CustomerProfileService.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

public class FormRepository : IFormRepository
{
    private readonly AppDbContext _context;

    public FormRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<QuestionForm> AddAsync(QuestionForm form)
    {
        await _context.QuestionForm.AddAsync(form);
        await _context.SaveChangesAsync();

        return form;
    }

    public async Task<QuestionForm?> GetByIdAsync(Guid id)
    {
        var questionForm = await _context
            .QuestionForm
            .Include(q => q.Questions)
                .ThenInclude(q => q.Options)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
        
        return questionForm;
    }
    
    public async Task<QuestionForm?> GetMostRecentAsync()
    {
        var questionForm = await _context
            .QuestionForm
            .Include(q => q.Questions)
            .ThenInclude(q => q.Options)
            .OrderBy(f => f.CreatedAt)
            .FirstOrDefaultAsync();
        
        return questionForm;
    }

    public Task AddFormAnswerAsync(List<FormAnswer> formAnswers)
    {
        _context.FormAnswers.AddRange(formAnswers);
        return _context.SaveChangesAsync();
    }
}