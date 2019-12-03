using RegWatcher.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegWatcher.Models.ViewModels
{
    public class DocumentModel
    {
        [Required]
        public string Data { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public DocumentTypes DocumentType { get; set; }

        [Required]
        [RegularExpression(@"^[{(]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[)}]?$")]
        public string ResponsibleUserId { get; set; }

        public DateTimeOffset DeadLine { get; set; }

        [Required]
        [RegularExpression(@"^[A_Za-zА-Яа-яЁё0-9_!~=+-]{1,255}\.[A_Za-z0-9_!~=+-]+$", 
            ErrorMessage = "Длина имя файла должна быть от 1 до 255 символов, и имя файла не должно содержать точки")]
        public string FileName { get; set; }
    }
}
