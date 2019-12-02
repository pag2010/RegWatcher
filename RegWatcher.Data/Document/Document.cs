using RegWatcher.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegWatcher.Data
{
    public class Document
    {
        public int DocumentId { get; set; }

        [Required]
        [StringLength(20)]
        public string Number { get; set; }

        public ApplicationUser ResponsibleUser { get; set; }

        [Required]
        public File File { get; set; }
        
        public DateTimeOffset DeadLine { get; set; }

        [Required]
        public Step Step { get; set; }

        public Tag Tag { get; set; }
    }
}
