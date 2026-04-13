public interface IFormService
{
    Task<QuestionForm> CreateForm();
    Task<QuestionForm?> GetForm(Guid id);
}