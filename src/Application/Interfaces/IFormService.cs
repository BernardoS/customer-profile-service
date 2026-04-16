using CustomerProfileService.Application.DTOs;

public interface IFormService
{
    Task<QuestionForm> CreateForm();
    Task<QuestionForm?> GetForm(Guid id);
    Task<QuestionForm?> GetLastForm();
    Task<Question> AddQuestion(CreateQuestionInput input);
}