using Microsoft.AspNetCore.Mvc.Filters;
using RegWatcher.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegWatcher.Filters
{
    public class AuthorizeFilterAttribute : ActionFilterAttribute
    {
        private readonly ApplicationUser _user;

        public AuthorizeFilterAttribute(ApplicationUser user)
        {
            _user = user;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var kek = _user;
        }
    }
}
