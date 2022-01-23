using AutoMapper;
using BusinessLogic.DTO;
using DataAccess.DTO;

namespace DataAccess.Mapping
{
    public class EntitiesToDTOProfile : Profile
    {
        public EntitiesToDTOProfile()
        {
            CreateMap<Catalog, CatalogDTO>();
            CreateMap<Title, TitleDTO>();
        }
    }
}
