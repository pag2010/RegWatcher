using RegWatcher.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegWatcher.Models.ViewModels
{
    public class PersonModel
    {
        public int? PersonId { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SecondName { get; set; }
        public string LastName { get; set; }

        [Phone]
        public string PhoneNumber {get;set;}

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int PositionId { get; set; }

        public Person GetPerson()
        {
            return new Person()
            {
                Email = this.Email,
                FirstName = this.FirstName,
                LastName = this.LastName,
                PhoneNumber = this.PhoneNumber,
                PositionId = this.PositionId,
                SecondName = this.SecondName
            };
        }
    }
}
