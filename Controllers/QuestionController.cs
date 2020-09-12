using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeirdBack.Services;

namespace WeirdBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }



        //GET: api/Question/Get/id
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _questionService.Get(id);

            return Ok(result);
        }
    }
}
