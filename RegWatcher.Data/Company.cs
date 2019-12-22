using RegWatcher.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegWatcher.Data
{
    public class Company
    {
        public int CompanyId { get; set; }

        [Required]
        public string FullName { get; set; }

        public string ShortName { get; set; }

        public int FormKindId { get; set; }

        public virtual FormKind FormKind {get; set;}

        [Required]
        public int PersonId { get; set; }
        [Required]
        public virtual Person Person { get; set; }

        [Required]
        [StringLength(12)]
        public string Inn { get; set; }

        [StringLength(9)]
        public string Kpp { get; set; }

        [StringLength(15)]
        public string Ogrn { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string BusinessSubject { get; set; }

        public string Comment { get; set; }

        public DateTime CreationTime { get; set; } = DateTime.Now;

        public DateTime? UpdateTime { get; set; }

        [StringLength(36)]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public Steps StepId { get; set; }
        public virtual Step Step { get; set; }
    }
}
