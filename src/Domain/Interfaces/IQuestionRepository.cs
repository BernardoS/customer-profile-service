namespace CustomerProfileService.Domain.Interfaces
{
    public interface IQuestionRepository
    {
        Task<Question> AddAsync(Question question);
        Task UpdateAsync(Question question);
        Task RemoveAsync(Question question);
        Task<Question?> GetAsync(Guid id);
        Task<Question> GetByFormAsync(Guid formId);
    }
}