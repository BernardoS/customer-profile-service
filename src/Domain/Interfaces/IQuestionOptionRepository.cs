namespace CustomerProfileService.Domain.Interfaces
{
    public interface IQuestionOptionRepository
    {
        Task AddAsync(QuestionOption option);
        Task UpdateAsync(Question question);
        Task RemoveAsync(Question question);
        Task<Question> GetAsync(Guid id);
        Task<Question> GetByQuestion(Guid questionId);
    }
}