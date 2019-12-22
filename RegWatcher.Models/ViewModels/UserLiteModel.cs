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
            var LastName = user.Person.LastName == "" ? string.Empty : " "+user.Person.LastName;
            Name = string.Format($"{user.Person.FirstName} {user.Person.SecondName}{LastName}").Trim();
        }
    }
}
