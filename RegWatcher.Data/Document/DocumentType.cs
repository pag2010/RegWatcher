using RegWatcher.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegWatcher.Data
{
    public class DocumentType
    {
        public DocumentTypes DocumentTypeId { get; set; }

        [Required]
        [StringLength(255)]
        public string TypeName {get;set;}
    }
}
