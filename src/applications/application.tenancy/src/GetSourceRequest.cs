using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace application.tenancy
{
    public class GetSourceRequest : IRequest<string>
    {
    }

    internal class GetSourceRequestHandler : IRequestHandler<GetSourceRequest, string>
    {
        private readonly ISourceService _sourceService;

        public GetSourceRequestHandler (ISourceService sourceService)
        {
            _sourceService = sourceService;
        }

        public Task<string> Handle(GetSourceRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_sourceService.GetSource());
        }
    }
}
