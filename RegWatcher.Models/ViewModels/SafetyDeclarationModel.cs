using RegWatcher.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegWatcher.Models.ViewModels
{
    public class SafetyDeclarationModel
    {
        public int? SafetyDeclarationId { get; set; }
        [Required]
        public int GTSId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        public int? DocumentId { get; set; }

        public SafetyDeclarationModel()
        {

        }

        public SafetyDeclarationModel(SafetyDeclaration declaration)
        {
            this.SafetyDeclarationId = declaration.SafetyDeclarationId;
            this.GTSId = declaration.GTSId;
            this.StartDate = declaration.StartDate;
            this.EndDate = declaration.EndDate;
            this.DocumentId = declaration.DocumentId;
        }

        public SafetyDeclaration GetSafetyDeclaration()
        {
            var sd = new SafetyDeclaration();
            sd.EndDate = this.EndDate;
            sd.GTSId = this.GTSId;
            if (this.SafetyDeclarationId.HasValue)
                sd.SafetyDeclarationId = this.SafetyDeclarationId.Value;
            sd.StartDate = this.StartDate;

            if (this.DocumentId.HasValue)
                sd.DocumentId = this.DocumentId.Value;
            return sd;
        }
    }
}
