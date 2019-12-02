using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegWatcher.Data
{
    public class File
    {
        public int FileId { get; set; }
        public Guid Guid { get; set; } = new Guid();
        public DateTimeOffset CreationDate { get; set; } = DateTimeOffset.Now;

        [Required]
        public FileExtension FileExtension { get; set; }
    }
}
