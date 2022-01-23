using BusinessLogic.DTO;
using BusinessLogic.ParametrObjects.Requests.Catalogs;
using BusinessLogic.Repositories;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Services.Requests.Catalogs
{
    public class GetAllCatalogsHandler : IRequestHandler<GetAllCatalogsRequest, IEnumerable<CatalogDTO>>
    {
        private readonly ICatalogsRepository _catalogsRepository;

        public GetAllCatalogsHandler(ICatalogsRepository catalogsRepository)
        {
            _catalogsRepository = catalogsRepository
                ?? throw new ArgumentNullException(nameof(catalogsRepository));
        }

        public IEnumerable<CatalogDTO> Execute(GetAllCatalogsRequest request)
        {
            return _catalogsRepository.GetAll();
        }
    }
}
