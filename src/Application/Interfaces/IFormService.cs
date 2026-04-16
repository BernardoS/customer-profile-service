using CustomerProfileService.Application.DTOs;

public interface IFormService
{
    Task<QuestionForm> CreateForm();
    Task<QuestionForm?> GetForm(Guid id);
    Task<QuestionForm?> GetMostRecentForm();
    Task<Question> AddQuestion(CreateQuestionInput input);
}