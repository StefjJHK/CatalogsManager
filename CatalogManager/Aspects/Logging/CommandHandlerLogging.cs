using BusinessLogic.Services.Commands;
using Microsoft.Extensions.Logging;
using System;

namespace CatalogsManager.Aspects.Logging
{
    public class CommandHandlerLogging<T>  : ICommandHandler<T>
        where T : class
    {
        private readonly ICommandHandler<T> _commandHandler;
        private readonly ILogger<CommandHandlerLogging<T>> _logger;

        public CommandHandlerLogging(ICommandHandler<T> commandHandler, ILogger<CommandHandlerLogging<T>> logger)
        {
            _commandHandler = commandHandler ??
                throw new ArgumentNullException(nameof(commandHandler));
            _logger = logger ?? 
                throw new ArgumentNullException(nameof(logger));
        }

        public void Execute(T command)
        {
            using (_logger.BeginScope(LoggingStatics.GetProperties(command)))
            {
                _logger.LogInformation("[{DateTime}] Handling {CommandName}.", 
                    DateTimeOffset.Now, typeof(T).Name);

                _commandHandler.Execute(command);

                _logger.LogInformation("[{DateTime}] Completed handling {CommandName}.", 
                    DateTimeOffset.Now, typeof(T).Name);
            }
        }
    }
}
