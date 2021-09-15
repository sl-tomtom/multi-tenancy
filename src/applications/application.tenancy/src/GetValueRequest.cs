using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace application.tenancy
{

    public class BaseRequest<TResult> :IRequest<TResult>
    {
        public string Infrastructure { get; set; }
    }

    public class GetValueRequest : BaseRequest<int>
    {

    }

    internal class GetValueRequestHandler : IRequestHandler<GetValueRequest, int>
    {
        private readonly IInfrastructureProvider<IValueService> _valueServiceProvider;
        public GetValueRequestHandler(IInfrastructureProvider<IValueService> valueServiceProvider)
        {
            this._valueServiceProvider = valueServiceProvider;
        }

        public Task<int> Handle(GetValueRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_valueServiceProvider.GetService().GetValue());
        }
    }
}
