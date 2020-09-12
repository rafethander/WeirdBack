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
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;
        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }


        //GET: api/Topic/Get
        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var result = await _topicService.Get();

            return Ok(result);
        }
    }
}
