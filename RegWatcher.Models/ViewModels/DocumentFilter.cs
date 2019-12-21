using System;
using System.Collections.Generic;
using System.Text;

namespace RegWatcher.Models.ViewModels
{
    public class DocumentFilter
    {
        public string UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? StepId { get; set; }
        public int? DocumentTypeId { get; set; }
        public bool IsResponsible { get; set; }
        public bool IsOwner { get; set; }
        public string DocumentNumber { get; set; }
    }
}
