using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBlogWebSite.Models;
using MyBlogWebSite.Services;

namespace MyBlogWebSite.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService blogService;

        public BlogController(IBlogService blogService)
        {
            this.blogService = blogService;
        }
        
        public IActionResult Index()
        {
            BlogViewModel blogViewModel = new BlogViewModel();
            blogViewModel.Blogs = blogService.GetBlogs().ToList();
            blogViewModel.ImagePath = ImageFilePath();
            return View(blogViewModel);
        }

        public string ImageFilePath()
        {
            return "/img/uploads/blogs";
        }
    }

}
