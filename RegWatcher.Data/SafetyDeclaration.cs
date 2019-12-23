using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegWatcher.Data
{
    public class SafetyDeclaration
    {
        public int SafetyDeclarationId { get; set; }
        [Required]
        public int GTSId { get; set; }
        public virtual GTS GTS { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        public int? DocumentId { get; set; }
        public virtual Document Document { get; set; }
    }
}
