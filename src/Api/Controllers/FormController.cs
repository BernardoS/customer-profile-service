using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerProfileService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormController : ControllerBase
    {
        private IFormService _formService;

        public FormController(IFormService formService)
        {
            _formService = formService;
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetForm(Guid id)
        {
            var form = await _formService.GetForm(id);
            
            if(form == null)
                return NotFound("Nenhum formulário encontrado, verifique o identificador enviado");
            
            return Ok(form);
        }
        
        [HttpGet]
        [Route("MostRecent")]
        [Authorize]
        public async Task<IActionResult> GetMostRecentForm()
        {
            var form = await _formService.GetMostRecentForm();
            
            if(form == null)
                return NotFound("Nenhum formulário encontrado, crie um formulário antes de realizar esta busca.");
            
            return Ok(form);
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateForm()
        {
            var form  = await _formService.CreateForm();
            
            return Created("/api/form",new {id = form.Id});
        }
        
        [HttpPost]
        [Route("Question")]
        [Authorize]
        public async Task<IActionResult> CreateQuestion(CreateQuestionRequest request)
        {
            var question = request.MapToQuestionInput();
            
            await _formService.AddQuestion(question);
            
            return Created("/api/form",new {id = request.FormId});
        }
        
    }
}
