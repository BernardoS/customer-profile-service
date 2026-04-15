namespace CustomerProfileService.Application.DTOs
{
    public class CreateQuestionInput
    {
        public Guid FormId { get; set; }
        
        public string QuestionTitle { get; set; }
        
        public List<CreateQuestionOptionInput?> QuestionOptions { get; set; }
    }
}

