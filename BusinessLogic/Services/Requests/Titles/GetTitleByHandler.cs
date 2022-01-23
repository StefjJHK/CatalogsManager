using BusinessLogic.DTO;
using BusinessLogic.ParametrObjects.Requests.Titles;
using BusinessLogic.Repositories;
using System;

namespace BusinessLogic.Services.Requests.Titles
{
    public class GetTitleByHandler : IRequestHandler<GetTitleByIdRequest, TitleDTO>
    {
        private readonly ITitlesRepository _repository;

        public GetTitleByHandler(ITitlesRepository repository)
        {
            _repository = repository 
                ?? throw new ArgumentNullException(nameof(repository));
        }

        public TitleDTO Execute(GetTitleByIdRequest request)
        {
            return _repository.GetById(request.Id);
        }
    }
}
