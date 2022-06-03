using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlazorBlog.Data.Entities.Blog;
using BlazorBlog.Model.DTos;

namespace BlazorBlog.Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BlogsDTO, Blogs>();
            CreateMap<Blogs, BlogsDTO>();
        }
    }
}
