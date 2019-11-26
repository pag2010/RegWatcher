using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegWatcher.Models.ViewModels
{
    public class EmailModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
