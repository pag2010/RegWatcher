using System;
using System.Collections.Generic;
using System.Text;

namespace RegWatcher.Models.ViewModels
{
    public class UserFilter
    {
        public string UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserSecondName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string RoleName { get; set; }
    }
}
