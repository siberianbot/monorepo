using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace TeamWorks.WebApi
{
    internal sealed partial class Startup
    {
        private void ConfigureAuthentication(IServiceCollection services) => services
                .AddAuthorization()
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
#if DEBUG
                    options.RequireHttpsMetadata = false;
#endif

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = Constants.Authentication.Issuer,

                        ValidateAudience = true,
                        ValidAudience = Constants.Authentication.Audience,

                        ValidateLifetime = true,

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = 
                    };
                });
    }
}