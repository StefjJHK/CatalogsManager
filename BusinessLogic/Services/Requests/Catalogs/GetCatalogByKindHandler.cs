using BusinessLogic.DTO;
using BusinessLogic.ParametrObjects.Requests.Catalogs;
using BusinessLogic.Repositories;
using System;
using System.Linq;

namespace BusinessLogic.Services.Requests.Catalogs
{
    public class GetCatalogByKindHandler : IRequestHandler<GetCatalogByKindRequest, CatalogDTO>
    {
        private readonly ICatalogsRepository _repository;

        public GetCatalogByKindHandler(ICatalogsRepository repository)
        {
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));
        }

        public CatalogDTO Execute(GetCatalogByKindRequest request)
        {
            return _repository
                .GetAll()
                .FirstOrDefault(catalog => string.Equals(catalog.Kind, request.Kind, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
