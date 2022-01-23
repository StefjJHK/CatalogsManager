using BusinessLogic.ParametrObjects.Commands.Titles;
using BusinessLogic.Repositories;
using System;

namespace BusinessLogic.Services.Commands.Titles
{
    public class CreateTitleHandler : ICommandHandler<CreateTitleCommand>
    {
        private readonly ITitlesRepository _repository;
        public CreateTitleHandler(ITitlesRepository repository)
        {
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));
        }
        public void Execute(CreateTitleCommand command)
        {
            _repository.Create(command.Title);
        }
    }
}
