using System;
using System.Collections.Generic;
using System.Text;

namespace RegWatcher.Data
{
    public class Person
    {
        public int PersonId { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
    }
}
