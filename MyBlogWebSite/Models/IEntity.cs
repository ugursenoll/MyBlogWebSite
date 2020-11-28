using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogWebSite.Models
{
    public interface IEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public bool IsPublished { get; set; }
        public string ImageName { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
