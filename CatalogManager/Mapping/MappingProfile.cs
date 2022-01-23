using AutoMapper;
using BusinessLogic.DTO;
using CatalogsManager.ViewModels;

namespace CatalogsManager.Mapping
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
