using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using System.Net;
using System.Text.Encodings.Web;

namespace ResourceOwnerCredentials.API
{
    public class WriteJwtBearer : CustomJwtBearerHandler
    {
        public WriteJwtBearer(IOptionsMonitor<JwtBearerOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var result=await base.HandleAuthenticateAsync();

            if (!result.Succeeded)
            {
                return AuthenticateResult.Fail("hata");
            }
            var resultpr = result.Principal.Claims.ToList();
            if (!result.Principal.Claims.Any(y => y.Value == "api.write"))
            {
                throw new HttpRequestException("Unauthorized", null, HttpStatusCode.Forbidden);
            }

            return AuthenticateResult.Success(new AuthenticationTicket(result.Principal, "JwtBearerWrite"));

        }
    }
}
