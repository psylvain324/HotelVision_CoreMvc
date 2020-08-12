using System;
using HotelVision_CoreMvc.Data;
using Microsoft.Extensions.Logging;

namespace HotelVision_CoreMvc.Controllers
{
    public class BlogPostController
    {

        private readonly ILogger<BlogPostController> logger;
        private readonly DatabaseContext databaseContext;

        public BlogPostController(ILogger<BlogPostController> logger, DatabaseContext databaseContext)
        {
            this.logger = logger;
            this.databaseContext = databaseContext;
        }

      
    }
}
