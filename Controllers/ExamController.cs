using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeirdBack.Dtos;
using WeirdBack.Helper;
using WeirdBack.Services;

namespace WeirdBack.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class ExamController:ControllerBase
    {
        private readonly IExamService _examService;
        public ExamController(IExamService examService)
        {
            _examService = examService;
        }



        //POST : api/Exam/Add
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody]ExamAddDto model)
        {
            var result = await _examService.Add(model);

            if (result.Message != ApiResultMessages.Ok)
                return BadRequest(result);


            return Ok(result);

        }

        //DELETE: api/Exam/Delete/{id}
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _examService.Delete(id);

            if (result.Message != ApiResultMessages.Ok)
                return BadRequest(result);

            return Ok(result);
        }


        //GET: api/Exam/Get
        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var result = await _examService.Get();

            return Ok(result);
        }


        //GET: api/Exam/Get/{id}
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetWithId(Guid id)
        {
            var result = await _examService.GetWithId(id);

            return Ok(result);
        }
    }
}
