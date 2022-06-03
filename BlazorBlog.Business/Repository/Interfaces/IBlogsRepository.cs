using BlazorBlog.Model.DTos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBlog.Business.Repository.Interfaces
{
    public interface IBlogsRepository
    {
        public Task<BlogsDTO> CreateBlog(BlogsDTO blogDTO);
        public Task<BlogsDTO> UpdateBlog(int blogId,BlogsDTO blogDTO);
        public Task<BlogsDTO> GetBlogById(int blogId);
        public Task<IEnumerable<BlogsDTO>> GetAllBlogs();

        public Task<IEnumerable<BlogsDTO>> GetAllBlogsByCount(int count);

        public Task<int> RemoveBlog(int blogId);
        public Task<int> RemoveBlog(BlogsDTO blogDTO);

    }
}
