using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;

namespace RegWatcher.Data
{
    public class ApplicationUser : IdentityUser
    {
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        public DateTime DateOff { get; set; }
        public string ConfirmedByUserId { get; set; }
        public virtual ApplicationUser ConfirmedByUser { get; set; }
        public ApplicationUser():base()
        {
        }
    }
}
