using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TeamWorks.WebApi.Infrastructure;

namespace TeamWorks.WebApi
{
    internal sealed partial class Startup
    {
        private SecurityOptions _securityOptions;
        
        private void ConfigureOptions(IServiceCollection services)
        {
            _securityOptions = _configuration.GetSection("security").Get<SecurityOptions>();
            _securityOptions.IssuerSigningCertKey = GetSecurityKey(_securityOptions);
            services.<SecurityOptions>(_securityOptions);
            
            services.AddOptions<SecurityOptions>("security")
                .PostConfigure(options =>
                {
                    // TODO:
                    options.IssuerSigningCertKey = GetSecurityKey(options);
                })
                .Validate(options => !string.IsNullOrEmpty(options.IssuerSigningCertPath), "Invalid security options.");
        }

        private X509SecurityKey GetSecurityKey(SecurityOptions securityOptions)
        {
            if (string.IsNullOrEmpty(securityOptions?.IssuerSigningCertPath))
            {
                throw new InvalidOperationException("Issuer certificate is required.");
            }

            X509Certificate2 certificate = new X509Certificate2(securityOptions.IssuerSigningCertPath, securityOptions.IssuerSigningCertPassword);

            return new X509SecurityKey(certificate);
        }
    }
}