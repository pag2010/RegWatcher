using RegWatcher.Data;
using RegWatcher.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegWatcher.Models.ViewModels
{
    public class CheckingModel
    {
        public int? CheckingId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public DateTime CheckingDate { get; set; }

        public DateTime? CloseDate { get; set; }

        [Required]
        public int GTSId { get; set; }

        [Required]
        public int CheckingKindId { get; set; }

        public string Reason { get; set; }
        public int? DocumentReasonId { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public Steps? StepId { get; set; }

        public CheckingModel()
        {

        }

        public CheckingModel(Checking checking)
        {
            this.CheckingDate = checking.CheckingDate;
            this.CheckingId = checking.CheckingId;
            this.CheckingKindId = checking.CheckingKindId;
            this.CreationDate = checking.CreationDate;
            this.DocumentReasonId = checking.DocumentReasonId;
            this.GTSId = checking.GTSId;
            this.Number = checking.Number;
            this.Reason = checking.Reason;
            this.StepId = checking.StepId;
            this.UserId = checking.UserId;
            this.CloseDate = checking.CloseDate;
        }

        public Checking GetChecking()
        {
            var checking = new Checking();
            if (this.CheckingId.HasValue)
                checking.CheckingId = this.CheckingId.Value;

            checking.CloseDate = this.CloseDate;

            checking.CheckingDate = this.CheckingDate;
            checking.CheckingKindId = this.CheckingKindId;
            checking.CreationDate = this.CreationDate;
            checking.DocumentReasonId = this.DocumentReasonId;
            checking.GTSId = this.GTSId;
            checking.Number = this.Number;
            checking.Reason = this.Reason;
            checking.StepId = this.StepId;
            checking.UserId = this.UserId;
 
            return checking;
        }
    }
}
