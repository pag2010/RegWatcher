using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegWatcher.Data
{
    public class DangerKind
    {
        public int DangerKindId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
