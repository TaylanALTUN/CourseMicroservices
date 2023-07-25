using AutoMapper;
using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Model;
using MongoDB.Driver.Core.Misc;

namespace FreeCourse.Services.Catalog.Mapping
{
    internal class GeneralMapping:Profile
    {
        internal GeneralMapping()
        {
            CreateMap<Course,CourseDto>().ReverseMap();
            CreateMap<Category,CategoryDto>().ReverseMap();
            CreateMap<Model.Feature, FeatureDto>().ReverseMap();

            CreateMap<Course,CourseCreateDto>().ReverseMap();
            CreateMap<Course,CourseUpdateDto>().ReverseMap();
        }
    }
}
