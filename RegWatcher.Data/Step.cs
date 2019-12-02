using RegWatcher.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegWatcher.Data
{
    public class Step
    {
        public Steps StepId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
