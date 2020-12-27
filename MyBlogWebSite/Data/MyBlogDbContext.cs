using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBlogWebSite.Models;

namespace MyBlogWebSite.Data
{
    public class MyBlogDbContext : DbContext
    {
        public MyBlogDbContext(DbContextOptions<MyBlogDbContext> options)
            : base(options)
        {
        }
        public DbSet<Blog> Blogs { get; set; }

    }
}
