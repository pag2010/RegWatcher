using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegWatcher.Models.ViewModels
{
    public class ConfirmEmailModel
    {
        [Required]
        public string Token { get; set; }
    }
}
