using RegWatcher.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RegWatcher.Data
{
    public class File
    {
        public int FileId { get; set; }
        public Guid Guid { get; set; } = new Guid();
        public DateTimeOffset CreationDate { get; set; } = DateTimeOffset.Now;

        [Required]
        public FileExtensions FileExtensionId { get; set; }

        [Required]
        [StringLength(255)]
        public string FileName{ get; set; }

        [Required]
        [ForeignKey("FileExtensionId")]
        public FileExtension FileExtension { get; set; }

        public string Data { get; set; }
    }
}
