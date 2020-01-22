using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HotelVision_React_Blog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogPostController : ControllerBase
    {
        private readonly ILogger<BlogPostController> logger;

        public BlogPostController(ILogger<BlogPostController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<BlogPost> Get()
        {
            return Ok(employeeRepository.Get(id));
        }
    }
}
