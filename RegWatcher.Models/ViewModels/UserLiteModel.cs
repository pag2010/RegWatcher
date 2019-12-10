using RegWatcher.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegWatcher.Models.ViewModels
{
    public class UserLiteModel
    {
        public string Email { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }

        public UserLiteModel(ApplicationUser user)
        {
            Email = user.Email;
            Id = user.Id;
            var LastName = user.LastName == "" ? string.Empty : " "+user.LastName;
            Name = string.Format($"{user.FirstName} {user.SecondName}{user.LastName}");
        }
    }
}
