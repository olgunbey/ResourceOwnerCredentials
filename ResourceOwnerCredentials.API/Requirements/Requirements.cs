using Microsoft.AspNetCore.Authorization;

namespace ResourceOwnerCredentials.API.Requirements
{
    public class Requirements : IAuthorizationRequirement
    {
    }
    public class Handler : AuthorizationHandler<Requirements>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, Requirements requirement)
        {
          var t =  context.User.Claims.ToList();

        }
    }
}
