using CustomerProfileService.Domain.Interfaces;

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
        var questionForm = await _context.QuestionForm.FindAsync(id);
        
        return questionForm;
    }
}