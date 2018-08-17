using System.Collections.Generic;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BuyFood.Service.WebAPI.Filters
{
    public class AddRequiredHeaderParameter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<IParameter>();

            operation.Parameters.Add(new HeaderParameter
            {
                Name = "X-API-Version",
                In = "header",
                Type = "string",
                Required = true
            });
        }

        private class HeaderParameter : NonBodyParameter { }
    }
}
