using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace RegWatcher.Data
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser():base()
        {
        }
    }
}
