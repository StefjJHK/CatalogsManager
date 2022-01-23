using AutoMapper;
using BusinessLogic.DTO;
using CatalogManager.ViewModels;

namespace CatalogManager.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CatalogDTO, CatalogViewModel>();
            CreateMap<TitleDTO, TitleViewModel>();

            CreateMap<CatalogViewModel, CatalogDTO>();
            CreateMap<TitleViewModel, TitleDTO>();
        }
    }
}
