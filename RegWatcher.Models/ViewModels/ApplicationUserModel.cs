using RegWatcher.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegWatcher.Models.ViewModels
{
    public class ApplicationUserModel
    {
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public IEnumerable<string> Roles {get;set;}
        public string ConfirmedByUserId { get; set; }
    }
}
