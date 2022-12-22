using Microsoft.AspNetCore.Mvc.Filters;

namespace SUBU.API.Filters;

public class AuthFilter : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        throw new NotImplementedException();
    }
}
