using AutoMapper;
using BusinessLogic.DTO;
using DataAccess.DTO;

namespace DataAccess.Mapping
{
    public class DTOToEntitiesProfile : Profile
    {
        public DTOToEntitiesProfile()
        {
            CreateMap<CatalogDTO, Catalog>();
            CreateMap<TitleDTO, Title>();
        }
    }
}
