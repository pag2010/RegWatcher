using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RegWatcher.Data
{
    public class DocumentTag
    {
        public int DocumentId { get; set; }
        public virtual Document Document { get; set; }

        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
