using RegWatcher.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegWatcher.Data
{
    public class FileExtension
    {
        [Required]
        public FileExtensions FileExtensionId { get; set; }

        [Required]
        [StringLength(20)]
        public string ExtensionName { get; set; }
    }
}
