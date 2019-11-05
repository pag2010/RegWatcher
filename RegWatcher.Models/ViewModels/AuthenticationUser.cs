using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegWatcher.Models.ViewModels
{
    public class AuthenticationUser : User
    {
       public bool RememberMe { get; set; }
    }
}
