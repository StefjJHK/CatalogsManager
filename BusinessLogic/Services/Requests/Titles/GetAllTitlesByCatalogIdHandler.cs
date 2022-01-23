using BusinessLogic.DTO;
using BusinessLogic.ParametrObjects.Requests.Titles;
using BusinessLogic.Repositories;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Services.Requests.Titles
{
    public class GetAllTitlesByCatalogIdHandler : IRequestHandler<GetAllTitlesByCatalogIdRequest, IEnumerable<TitleDTO>>
    {
        private readonly ITitlesRepository _repository;

        public GetAllTitlesByCatalogIdHandler(ITitlesRepository repository)
        {
            _repository = repository 
                ?? throw new ArgumentNullException(nameof(repository));
        }

        public IEnumerable<TitleDTO> Execute(GetAllTitlesByCatalogIdRequest request)
        {
            return _repository.GetAll(); 
        }
    }
}
