using BusinessLogic.Services.Requests;
using Microsoft.Extensions.Logging;
using System;

namespace CatalogsManager.Aspects.Logging
{
    public class RequestHandlerLogging<TRequest, TResponce> : IRequestHandler<TRequest, TResponce>
        where TRequest: class
    {
        private readonly IRequestHandler<TRequest, TResponce> _requestHandler;
        private readonly ILogger<RequestHandlerLogging<TRequest, TResponce>> _logger;

        public RequestHandlerLogging(IRequestHandler<TRequest, TResponce> requestHandler,
            ILogger<RequestHandlerLogging<TRequest, TResponce>> logger)
        {
            _requestHandler = requestHandler ??
                throw new ArgumentNullException(nameof(requestHandler));
            _logger = logger ?? 
                throw new ArgumentNullException(nameof(logger));
        }

        public TResponce Execute(TRequest request)
        {
            using (_logger.BeginScope(LoggingStatics.GetProperties(request)))
            {
                _logger.LogInformation("[{DateTime}] Handling {CommandName}.",
                    DateTimeOffset.Now, typeof(TRequest).Name);

                var responce = _requestHandler.Execute(request);

                _logger.LogInformation("[{DateTime}] Completed handling {CommandName}.",
                    DateTimeOffset.Now, typeof(TRequest).Name, LoggingStatics.GetProperties(responce));

                return responce;
            }
        }
    }
}
