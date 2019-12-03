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
        [ForeignKey("DocumentTypeId")]
        public DocumentType DocumentType { get; set; }

        public string ResponsibleUserId { get; set; }

        [ForeignKey("ResponsibleUserId")]
        public ApplicationUser ResponsibleUser { get; set; }

        [Required]
        public string OwnerUserId { get; set; }

        [Required]
        [ForeignKey("OwnerUserId")]
        public ApplicationUser OwnerUser { get; set; }

        [Required]
        public int FileId { get; set; }

        [Required]
        [ForeignKey("FileId")]
        public File File { get; set; }
        
        public DateTimeOffset DeadLine { get; set; }

        public DateTimeOffset CreationDate { get; set; } = DateTimeOffset.Now;

        [Required]
        public Steps StepId { get; set; }

        [Required]
        [ForeignKey("StepId")]
        public Step Step { get; set; }

        public List<DocumentTag> DocumentTags { get; set; }

        public Document()
        {
            this.DocumentTags = new List<DocumentTag>();
        }
    }
}
