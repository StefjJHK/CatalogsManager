using BusinessLogic.DTO;
using BusinessLogic.ParametrObjects.Requests.Catalogs;
using BusinessLogic.Repositories;
using System;

namespace BusinessLogic.Services.Requests.Catalogs
{
    public class GetCatalogByIdHandler : IRequestHandler<GetCatalogByIdRequest, CatalogDTO>
    {
        private readonly ICatalogsRepository _repository;
        public GetCatalogByIdHandler(ICatalogsRepository repository)
        {
            _repository = repository
                ?? throw new ArgumentNullException(nameof(repository));
        }

        public CatalogDTO Execute(GetCatalogByIdRequest request)
        {
            return _repository.GetById(request.Id);
        }
    }
}
