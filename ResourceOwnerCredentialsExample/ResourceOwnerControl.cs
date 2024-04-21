using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;

namespace ResourceOwnerCredentialsExample
{
    public class ResourceOwnerControl : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            if(context.UserName=="olgunbey" && context.Password=="Password123.")
            {
                context.Result = new GrantValidationResult("1", OidcConstants.AuthenticationMethods.Password);
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }
    }
}
