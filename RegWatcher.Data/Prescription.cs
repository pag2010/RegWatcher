using System;
using System.Collections.Generic;
using System.Text;

namespace RegWatcher.Data
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }
        public string Number { get; set; }
        public int? DocumentId { get; set; }
        public virtual Document Document { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
