using RegWatcher.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegWatcher.Data
{
    public class Checking
    {
        public int CheckingId { get; set; }

        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public DateTime CheckingDate { get; set; }

        public DateTime? CloseDate { get; set; }

        [Required]
        public int GTSId { get; set; }
        public virtual GTS GTS { get; set; }

        [Required]
        public int CheckingKindId { get; set; }
        public virtual CheckingKind CheckingKind {get;set;}

        public string Reason { get; set; }
        public int? DocumentReasonId { get; set; }
        public virtual Document DocumentReason { get; set; }

        public virtual List<CheckingResult> CheckingResults { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public Steps? StepId { get; set; }
        public virtual Step Step { get; set; }
    }
}
