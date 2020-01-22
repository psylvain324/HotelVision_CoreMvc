using System;
using System.Collections.Generic;
using System.Linq;
using HotelVision_CoreMvc.Data;
using HotelVision_CoreMvc.Models;
using HotelVision_CoreMvc.Services.Interfaces;
using Microsoft.Extensions.Logging;


namespace HotelVision_CoreMvc.Repositories
{
    public class SqlBlogPostRepository : IRepository<BlogPost>
    {
        private DatabaseContext databaseContext;
        private readonly ILogger logger;

        public SqlBlogPostRepository(DatabaseContext databaseContext, ILogger<SqlBlogPostRepository> logger)
        {
            this.databaseContext = databaseContext;
            this.logger = logger;
        }

        public bool Add(BlogPost blogPost)
        {
            try
            {
                databaseContext.BlogPosts.Add(blogPost);
                databaseContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError("Failed to add Blog Post item to the database: " + ex.Message);
                return false;
            }
        }

        public bool Delete(BlogPost blogPost)
        {
            try
            {
                BlogPost blog = Get(blogPost.Id);
                if (blog != null)
                {
                    databaseContext.BlogPosts.Remove(blog);
                    databaseContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                logger.LogError("Unable to delete Blog Post: " + ex.Message);
                return false;
            }
        }

        public bool Edit(BlogPost blogPost)
        {
            try
            {
                databaseContext.BlogPosts.Update(blogPost);
                databaseContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError("Unable to save Blog Post: " + ex.Message);
            }
            return false;
        }

        public BlogPost Get(int id)
        {
            if (databaseContext.InventoryItems.Count(x => x.Id == id) > 0)
            {
                return databaseContext.BlogPosts.First(x => x.Id == id);
            }
            return null;
        }

        public BlogPost Get(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            if (databaseContext.InventoryItems.Count(x => x.Id == id) > 0)
            {
                return databaseContext.BlogPosts.FirstOrDefault(x => x.Id == id);
            }
            return null;
        }

        public IEnumerable<BlogPost> GetAll()
        {
            return databaseContext.BlogPosts;
        }

        public bool Exists(int id)
        {
            return databaseContext.InventoryItems.SingleOrDefault(e => e.Id == id) != null;
        }
    }
}
