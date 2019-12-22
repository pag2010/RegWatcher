using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegWatcher.Data
{
    public class FormKind
    {
        public int FormKindId { get; set; }

        [Required]
        [StringLength (50)]
        public string FormNameFull { get; set; }

        [Required]
        [StringLength(10)]
        public string FormNameShort { get; set; }
    }
}
