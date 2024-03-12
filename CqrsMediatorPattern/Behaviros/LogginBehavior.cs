using MediatR;

namespace CqrsMediatorPattern.Behaviros
{
    public class LogginBehaviorn<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {

        private readonly ILogger<LogginBehaviorn<TRequest, TResponse>> _logger;

        public LogginBehaviorn(ILogger<LogginBehaviorn<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Handling {typeof(TRequest).Name}");
            var response = await next();

            _logger.LogInformation($"Handling {typeof(TResponse).Name}");

            return response;
        }
    }
}
