using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegWatcher.Data
{
    public class Tag
    {
        public int TagId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
