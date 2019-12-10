using RegWatcher.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RegWatcher.Data
{
    public class Document
    {
        public int DocumentId { get; set; }

        [Required]
        [StringLength(20)]
        public string Number { get; set; }

        [Required]
        public DocumentTypes DocumentTypeId { get; set; }

        [Required]
        public virtual DocumentType DocumentType { get; set; }

        [ForeignKey("ResponsibleUser")]
        public string ResponsibleUserId { get; set; }

        public virtual ApplicationUser ResponsibleUser { get; set; }

        [Required]
        public string OwnerUserId { get; set; }

        [ForeignKey("OwnerUserId")]
        public virtual ApplicationUser OwnerUser { get; set; }

        [Required]
        public int FileId { get; set; }

        [Required]
        public virtual File File { get; set; }

        public DateTimeOffset? DeadLine { get; set; } = null;

        public DateTimeOffset CreationDate { get; set; } = DateTimeOffset.Now;

        [Required]
        public Steps StepId { get; set; }

        [Required]
        public virtual Step Step { get; set; }

        public virtual List<DocumentTag> DocumentTags { get; set; }

        public Document()
        {
            this.DocumentTags = new List<DocumentTag>();
        }
    }
}
