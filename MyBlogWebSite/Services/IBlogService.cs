using MyBlogWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogWebSite.Services
{
    public interface IBlogService
    {
        public IEnumerable<Blog> GetBlogs();
    }
}
