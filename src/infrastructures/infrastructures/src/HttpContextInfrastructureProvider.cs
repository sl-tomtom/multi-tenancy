using System.Reflection;
using System.ComponentModel.Design;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using application.tenancy;

namespace infrastructures
{
    public partial class HttpContextInfrastructureProvider<TService> : IInfrastructureProvider<TService>
    {
        private readonly IEnumerable<TService> _services;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextInfrastructureProvider(IHttpContextAccessor accessor, IEnumerable<TService> services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
            _httpContextAccessor = accessor;
        }

        public TService GetService()
        {
            string channel = string.Empty;
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null && httpContext.Request.Headers.TryGetValue("channel", out var channelValue))
            {
                channel = channelValue;
            }

            if(string.IsNullOrWhiteSpace(channel))
                channel = "common";

            return _services.FirstOrDefault(service => service.GetType().Name.ToLower().Contains(channel)) ?? _services.Last();
        }
    }

}