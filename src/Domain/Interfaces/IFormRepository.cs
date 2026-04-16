namespace CustomerProfileService.Domain.Interfaces
{
    public interface IFormRepository
    {
        Task<QuestionForm> AddAsync(QuestionForm form);
        Task<QuestionForm?> GetByIdAsync(Guid id);
        Task<QuestionForm?> GetMostRecentAsync();
    }
}