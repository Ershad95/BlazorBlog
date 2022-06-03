using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBlog.Data.Entities.Blog
{
    public class Blogs
    {
        [Key]
        public int BlogId { get; set; }

       
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

       
        [Required]
        [MaxLength(500)]
        public string SmallDescription { get; set; }

      
        [Required]
        public string Description { get; set; }

      
        [Required]
        public string ImageName { get; set; }
  
        public bool IsActive { get; set; }

        public DateTime CreateDate { get; set; }

    }
}
