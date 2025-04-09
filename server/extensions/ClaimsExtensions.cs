using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace server.extensions
{
    public static class ClaimsExtensions
    {
    public static string GetUserEmail(this ClaimsPrincipal user)
    {
      return user.Claims.SingleOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")).Value;
       }
    }
}
