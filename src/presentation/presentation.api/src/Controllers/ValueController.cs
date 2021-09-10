using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediatR;
using application.tenancy;
using Microsoft.Extensions.DependencyInjection;

namespace presentation.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValueController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ValueController> _logger;
        private readonly ISender _sender;

        public ValueController(ILogger<ValueController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        [HttpGet]
        public Task<string> Get()
        {
            return _sender.Send(new GetValueRequest(), HttpContext.RequestAborted).ContinueWith(task => {
                if(task.IsCompletedSuccessfully){
                    switch(task.Result){
                        case 0 : return "Default";
                        case 1 : return "LogicImmo";
                        case 2 : return "SeLoger";
                        default: throw new IndexOutOfRangeException(nameof(task.Result));
                    }
                }
                throw task.Exception;
            });
        }
    }
}
