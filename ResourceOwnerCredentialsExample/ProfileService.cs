using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.Win32.SafeHandles;
using System.Security.Claims;

namespace ResourceOwnerCredentialsExample
{
    public class ProfileService : IProfileService
    {
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
          var userId= context.Subject.GetSubjectId();

            //burada o userId'ye ait roller dönülebilir
            Dictionary<string, string> Roles = new Dictionary<string, string>();
            Roles.Add("Roles", "Admin");

            
            var hasRoles= context.Client.AllowedScopes.ToList();
            var yx= context.RequestedClaimTypes.ToList();
            if(hasRoles.Any(y=>y=="Roles"))
            {
                var claims = new List<Claim>()
                {
                new Claim("Rol",Roles.Values.FirstOrDefault("Roles"))
                };
                context.IssuedClaims = claims;
            }

        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
        }
    }
}
