using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegWatcher.Data
{
    public class Position
    {
        public int PositionId { get; set; }

        [Required]
        [StringLength(255)]
        public string PositionName { get; set; }
    }
}
