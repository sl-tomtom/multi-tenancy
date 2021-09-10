using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace application.tenancy
{

    public class GetValueRequest : IRequest<int>
    {
    }

    internal class GetValueRequestHandler : IRequestHandler<GetValueRequest, int>
    {
        private readonly IValueService _valueService;
        public GetValueRequestHandler(IValueService valueService)
        {
            this._valueService = valueService;
        }

        public Task<int> Handle(GetValueRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_valueService.GetValue());
        }
    }
}
