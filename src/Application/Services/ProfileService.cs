using CustomerProfileService.Application.DTOs;
using CustomerProfileService.Application.Events;
using CustomerProfileService.Domain.Interfaces;

namespace CustomerProfileService.Application.Services
{
    public class ProfileService : IProfileService
    {
        private IFormRepository _formRepository;
        private IQuestionOptionRepository _questionOptionRepository;
        private IProfileRepository _profileRepository;
        private IEventPublisher _eventPublisher;

        public ProfileService(
            IFormRepository formRepository
            , IQuestionOptionRepository questionOptionRepository
            , IProfileRepository profileRepository
            , IEventPublisher eventPublisher
        )
        {
            _formRepository = formRepository;
            _questionOptionRepository = questionOptionRepository;
            _profileRepository = profileRepository;
            _eventPublisher = eventPublisher;
        }

        public async Task<Profile> CreateProfile(CreateProfileInput input)
        {
            var form = await _formRepository.GetByIdAsync(input.FormId);

            int maxScore = form?.GetMaxScore() ?? 0;

            var score = 0;

            var formAnswers = new List<FormAnswer>();

            foreach (var answer in input.Answers)
            {
                var questionOption = await _questionOptionRepository.GetAsync(answer.AnswerId);

                if (questionOption == null)
                    throw new Exception("Question option not found");

                score += questionOption.Score;

                formAnswers.Add(new FormAnswer(input.CustomerId, input.FormId, answer.QuestionId, answer.AnswerId));
            }

            var profile = new Profile(score, maxScore, input.CustomerId);

            await _profileRepository.AddAsync(profile);
            await _formRepository.AddFormAnswerAsync(formAnswers);

            var profileCreatedEvent = new ProfileCreatedEvent(profile.CustomerId, profile.ProfileId);

            await _eventPublisher.PublishAsync(profileCreatedEvent, profileCreatedEvent.EventId,
                profileCreatedEvent.EventName);
            
            return profile;
        }

        public Task<Profile> GetProfile(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}