using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace presentation.api.Swagger
{
    /// <summary>
    /// Adds Channel header to API endpoints
    /// </summary>
    /// <seealso cref="Swashbuckle.AspNetCore.SwaggerGen.IOperationFilter" />
    public class ChannelHeaderOperationFilter : IOperationFilter
    {
        /// <summary>
        /// Applies the specified operation.
        /// </summary>
        /// <param name="operation">The operation.</param>
        /// <param name="context">The context.</param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null) operation.Parameters = new List<OpenApiParameter>();

            var type = context.ApiDescription.ActionDescriptor.GetType();

            if (context.ApiDescription.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
            {
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "channel",
                    In = ParameterLocation.Header,
                    Description = "channel source",
                    Required = false,
                    AllowEmptyValue = true
                });
            }
        }
    }
}