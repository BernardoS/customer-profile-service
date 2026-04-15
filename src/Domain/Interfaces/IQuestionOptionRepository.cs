namespace CustomerProfileService.Domain.Interfaces
{
    public interface IQuestionOptionRepository
    {
        Task<QuestionOption> AddAsync(QuestionOption option);
        Task UpdateAsync(QuestionOption question);
        Task RemoveAsync(QuestionOption question);
        Task<QuestionOption> GetAsync(Guid id);
        Task<QuestionOption> GetByQuestion(Guid questionId);
    }
}