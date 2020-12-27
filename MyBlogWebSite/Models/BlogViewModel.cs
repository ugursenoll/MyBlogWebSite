using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogWebSite.Models
{
    public class BlogViewModel
    {
        public IList<Blog> Blogs { get; set; }
        public string ImagePath { get; set; }
    }
}
