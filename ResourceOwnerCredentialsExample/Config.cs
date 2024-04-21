using IdentityServer4;
using IdentityServer4.Models;

namespace ResourceOwnerCredentialsExample
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources => new List<ApiResource>()
        {
            new ApiResource("ApiResource")
            {
                Scopes={
                    "api.read",
                    "api.write",
                }
            },
        };
        public static IEnumerable<IdentityResource> GetIdentities => new List<IdentityResource>()
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource()
            {
                Name="Roles",
                DisplayName="Roles",
                UserClaims=new[]{"Rol"}
            }
        };
        public static IEnumerable<ApiScope> GetApiScopes => new List<ApiScope>()
        {
            new ApiScope("api.read","api için okuma"),
            new ApiScope("api.write","api için yazma")
        };
        public static IEnumerable<Client> GetClients => new List<Client>()
        {
            new Client()
            {
                ClientId="ResourceOwnerCredenialsExam",
                ClientSecrets=new Secret[]{new Secret("secret".Sha256())},
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                AllowOfflineAccess=true,
                AllowedScopes=new[] {
                    "api.write",
                    "api.read",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "Roles"
                }
            }
        };
       
    }
}
