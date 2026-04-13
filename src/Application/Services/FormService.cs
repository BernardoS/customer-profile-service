using CustomerProfileService.Domain.Interfaces;

namespace CustomerProfileService.Application.Services
{
    public class FormService : IFormService
    {
        private IFormRepository _formRepository;

        public FormService(IFormRepository formRepository)
        {
            _formRepository = formRepository;
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
    }
}