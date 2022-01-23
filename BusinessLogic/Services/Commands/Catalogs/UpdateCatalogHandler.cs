using BusinessLogic.ParametrObjects.Commands.Catalogs;
using BusinessLogic.Repositories;
using System;

namespace BusinessLogic.Services.Commands.Catalogs
{
    public class UpdateCatalogHandler : ICommandHandler<UpdateCatalogCommand>
    {
        private readonly ICatalogsRepository _repository;

        public UpdateCatalogHandler(ICatalogsRepository repository)
        {
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));
        }

        public void Execute(UpdateCatalogCommand command)
        {
            _repository.Update(command.Catalog);
        }
    }
}
