using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FamilyApplication
{/// <summary>
/// use bearer authentication for all controllers with authorize attribute in swagger
/// </summary>
    public class AuthenticationRequirementsFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Security ??= new List<OpenApiSecurityRequirement>();

            if (context.MethodInfo.DeclaringType != null &&
                context.MethodInfo.GetCustomAttributes(typeof(AuthorizeAttribute), false).Length <= 0 &&
                context.MethodInfo.DeclaringType.GetCustomAttributes(typeof(AuthorizeAttribute), false).Length <=
                0) return;
            var scheme = new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearer" } };
            operation.Security.Add(new OpenApiSecurityRequirement
            {
                [scheme] = new List<string>()
            });
        }
    }
}
