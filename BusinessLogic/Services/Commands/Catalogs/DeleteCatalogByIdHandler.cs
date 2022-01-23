using BusinessLogic.ParametrObjects.Commands.Catalogs;
using BusinessLogic.Repositories;
using System;

namespace BusinessLogic.Services.Commands.Catalogs
{
    public class DeleteCatalogByIdHandler : ICommandHandler<DeleteCatalogByIdCommand>
    {
        private readonly ICatalogsRepository _repository;

        public DeleteCatalogByIdHandler(ICatalogsRepository repository)
        {
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));
        }

        public void Execute(DeleteCatalogByIdCommand command)
        {
            _repository.DeleteById(command.Id);
        }
    }
}
