using Api.App.Commands.Categoria;
using AutoMapper;
using Models;

namespace Api.Infra.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
        }
    }
}
