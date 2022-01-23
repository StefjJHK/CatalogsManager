using BusinessLogic.ParametrObjects.Commands.Titles;
using BusinessLogic.Repositories;
using System;

namespace BusinessLogic.Services.Commands.Titles
{
    public class UpdateTitleHandler : ICommandHandler<UpdateTitleCommand>
    {
        private readonly ITitlesRepository _repository;

        public UpdateTitleHandler(ITitlesRepository repository)
        {
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));
        }

        public void Execute(UpdateTitleCommand command)
        {
            _repository.Update(command.Title);
        }
    }
}
