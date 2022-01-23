using BusinessLogic.ParametrObjects.Commands.Titles;
using BusinessLogic.Repositories;
using System;

namespace BusinessLogic.Services.Commands.Titles
{
    public class DeleteTitleByIdHandler : ICommandHandler<DeleteTitleByIdCommand>
    {
        private readonly ITitlesRepository _repository;

        public DeleteTitleByIdHandler(ITitlesRepository repository)
        {
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));
        }
        public void Execute(DeleteTitleByIdCommand command)
        {
            _repository.DeleteById(command.Id);
        }
    }
}
