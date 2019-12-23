using System;
using System.Collections.Generic;
using System.Text;

namespace RegWatcher.Data
{
    public class Act
    {
        public int ActId {get;set;}
        public string ActNumber { get; set; }
        public int? DocumentId { get; set; }
        public virtual Document Document { get; set; }
        public DateTime? Date { get; set; }
    }
}
