using AutoMapper;
using BlazorBlog.Business.Repository.Interfaces;
using BlazorBlog.Data.Context;
using BlazorBlog.Data.Entities.Blog;
using BlazorBlog.Model.DTos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBlog.Business.Repository
{
    public class BlogsRepository : IBlogsRepository
    {
        private readonly ApplicationDbContext context;

        private readonly IMapper mapper;


        public BlogsRepository(ApplicationDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;

        }
        public async Task<BlogsDTO> CreateBlog(BlogsDTO blogDTO)
        {
            var blogs = mapper.Map<BlogsDTO, Blogs>(blogDTO);
            blogs.CreateDate = DateTime.Now;
            var addBlogs = await context.Blogs.AddAsync(blogs);
            await context.SaveChangesAsync();

            return mapper.Map<Blogs, BlogsDTO>(addBlogs.Entity);

        }

        public async Task<IEnumerable<BlogsDTO>> GetAllBlogs()
        {
            try
            {
                IEnumerable<BlogsDTO> blogsDTOs = mapper.Map<IEnumerable<Blogs>, IEnumerable<BlogsDTO>>(await context.Blogs.ToListAsync());
                return blogsDTOs;

            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<IEnumerable<BlogsDTO>> GetAllBlogsByCount(int count)
        {
            try
            {
                var result = await context.Blogs
                    .OrderByDescending(b => b.CreateDate)
                    .Take(count)
                    .ToListAsync();

                IEnumerable<BlogsDTO> blogsDTOs = mapper.Map<IEnumerable<Blogs>, IEnumerable<BlogsDTO>>(result);
                return blogsDTOs;

            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<BlogsDTO> GetBlogById(int blogId)
        {
            try
            {
                BlogsDTO blogs = mapper.Map<Blogs, BlogsDTO>(await context.Blogs.SingleOrDefaultAsync(b => b.BlogId == blogId));
                return blogs;
            }
            catch (Exception ex)
            {

                return null;
            };
        }

        public async Task<int> RemoveBlog(int blogId)
        {
            var blog = await context.Blogs.FindAsync(blogId);
            if(blog !=null)
            {

                context.Blogs.Remove(blog);
                await context.SaveChangesAsync();

                return blog.BlogId;
            }
            return 0;
        }

        public async Task<int> RemoveBlog(BlogsDTO blogDTO)
        {
            return await RemoveBlog(blogDTO.BlogId);
        }

        public async Task<BlogsDTO> UpdateBlog(int blogId, BlogsDTO blogDTO)
        {
            try
            {
                if (blogId == blogDTO.BlogId)
                {
                    Blogs blogDetail = await context.Blogs.FindAsync(blogId);
                    Blogs blog = mapper.Map<BlogsDTO, Blogs>(blogDTO, blogDetail);
                    blog.CreateDate = DateTime.Now;
                    context.Blogs.Update(blog);
                    await context.SaveChangesAsync();

                    return mapper.Map<Blogs, BlogsDTO>(blog);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
