using MyBlogWebSite.Models;
using MyBlogWebSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogWebSite.Services
{
    public class BlogService : IBlogService
    {
        private IBlogRepository blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }
        public IEnumerable<Blog> GetBlogs()
        {
            return blogRepository.GetAll();
        }
    }
}
