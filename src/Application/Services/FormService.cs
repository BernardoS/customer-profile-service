using CustomerProfileService.Domain.Interfaces;
using CustomerProfileService.Application.DTOs;

namespace CustomerProfileService.Application.Services
{
    public class FormService : IFormService
    {
        private IFormRepository _formRepository;
        private IQuestionRepository _questionRepository;
        private IQuestionOptionRepository _questionOptionRepository;

        public FormService(
            IFormRepository formRepository,
            IQuestionRepository questionRepository,
            IQuestionOptionRepository questionOptionRepository)
        {
            _formRepository = formRepository;
            _questionRepository = questionRepository;
            _questionOptionRepository = questionOptionRepository;
        }

        public async Task<QuestionForm> CreateForm()
        {
            var form = new QuestionForm();

            var newForm = await _formRepository.AddAsync(form);

            return newForm;
        }

        public async Task<QuestionForm?> GetForm(Guid id)
        {
            var form = await _formRepository.GetByIdAsync(id);

            return form;
        }
        
        public async Task<QuestionForm?> GetLastForm()
        {
            var form = await _formRepository.GetLastAsync();

            return form;
        }

        public async Task<Question> AddQuestion(CreateQuestionInput input)
        {
            // Create Question
            var question = new Question(input.FormId, input.QuestionTitle);

            var createdQuestion = await _questionRepository.AddAsync(question);

            // Create Options
            if (input.QuestionOptions != null && input.QuestionOptions.Any())
            {
                foreach (var option in input.QuestionOptions)
                {
                    var questionOption = new QuestionOption(createdQuestion.Id, option.Description, option.Score);
                    _questionOptionRepository.AddAsync(questionOption);
                    createdQuestion.Options.Add(questionOption);
                }
            }

            return createdQuestion;
        }
    }
}