using JetBrains.Annotations;
using Microsoft.IdentityModel.Tokens;

namespace TeamWorks.WebApi.Infrastructure
{
    [UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
    internal sealed class SecurityOptions
    {
        public string IssuerSigningCertPath { get; set; }
        
        public string IssuerSigningCertPassword { get; set; }
        
        public X509SecurityKey IssuerSigningCertKey { get; set; }
    }
}