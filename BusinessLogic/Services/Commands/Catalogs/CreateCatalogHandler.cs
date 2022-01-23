using BusinessLogic.ParametrObjects.Commands.Catalogs;
using BusinessLogic.Repositories;
using System;

namespace BusinessLogic.Services.Commands.Catalogs
{
    public class CreateCatalogHandler : ICommandHandler<CreateCatalogCommand>
    {
        private readonly ICatalogsRepository _repository;

        public CreateCatalogHandler(ICatalogsRepository repository)
        {
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));
        }

        public void Execute(CreateCatalogCommand command)
        {
            _repository.Create(command.Catalog);
        }
    }
}
