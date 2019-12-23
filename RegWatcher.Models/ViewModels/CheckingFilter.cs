using RegWatcher.Data;
using RegWatcher.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegWatcher.Models.ViewModels
{
    public class CheckingFilter
    {
        public string UserName { get; set; }

        public string Number { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string Reason { get; set; }

        public Steps? StepId { get; set; }
    }
}
