using Infrastructure.Constants;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Infrastructure.Constants.Authorization;

namespace Infrastructure.Identity
{
    public class AuthorizeRoles : AuthorizeAttribute
    {
        public AuthorizeRoles(params Roles[] allowedRoles)
        {
            var allowedRolesAsStrings = allowedRoles.Select(x => Enum.GetName(typeof(Roles), x));
            Roles = string.Join(",", allowedRolesAsStrings);
        }
    }
}
