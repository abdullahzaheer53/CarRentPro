using System.Web.Http;
using WebActivatorEx;
using CarRentPro;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(CarRentPro.SwaggerConfig), "Register")]

namespace CarRentPro
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "CarRentPro");

                    // ✅ CHANGED: Uncommented and modified for JWT
                    c.ApiKey("Authorization")
                        .Description("Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIs...\"")
                        .Name("Authorization")
                        .In("header");

                    // c.IncludeXmlComments(GetXmlCommentsPath());
                })
                .EnableSwaggerUi(c =>
                {
                    // ✅ CHANGED: Uncommented this to show Authorize button
                    c.EnableApiKeySupport("Authorization", "header");
                });
        }
    }
}