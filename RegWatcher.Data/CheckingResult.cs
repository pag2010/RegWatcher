using System;
using System.Collections.Generic;
using System.Text;

namespace RegWatcher.Data
{
    public class CheckingResult
    {
        public int CheckingResultId { get; set; }
        public int CheckingId { get; set; }
        public virtual Checking Checking { get; set; }
        public int ViolationCount { get; set; }
        public decimal Fine { get; set; }
        public string Article { get; set; }
        public int ActId { get; set; }
        public virtual Act Act { get; set; }
        public int? PrescriptionId { get; set; }
        public virtual Prescription Prescription { get; set; }
    }
}
