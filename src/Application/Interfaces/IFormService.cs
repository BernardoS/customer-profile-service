using CustomerProfileService.Application.DTOs;

public interface IFormService
{
    Task<QuestionForm> CreateForm();
    Task<QuestionForm?> GetForm(Guid id);
    Task<Question> AddQuestion(CreateQuestionInput input);
}