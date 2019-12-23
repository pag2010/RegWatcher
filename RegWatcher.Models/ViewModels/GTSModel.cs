using RegWatcher.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegWatcher.Models.ViewModels
{
    public class GTSModel
    {
        public int? GTSId { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public int DangerKindId { get; set; }
        public string Purpose { get; set; }
        public List<int> SafetyDeclarationIds { get; set; }

        public GTSModel()
        {

        }

        public GTSModel(GTS gts)
        {
            this.GTSId = gts.GTSId;
            this.Name = gts.Name;
            this.Purpose = gts.Purpose;
            this.SafetyDeclarationIds = (gts.SafetyDeclarations != null) ? 
                gts.SafetyDeclarations.Select(sd => sd.SafetyDeclarationId).ToList() : new List<int>();
            this.DangerKindId = gts.DangerKindId;
            this.CompanyId = gts.CompanyId;
        }

        public GTS GetGTS()
        {
            var gts = new GTS();
            gts.CompanyId = this.CompanyId;
            gts.DangerKindId = this.DangerKindId;
            gts.Name = this.Name;
            gts.Purpose = this.Purpose;
            if (this.GTSId.HasValue)
                gts.GTSId = this.GTSId.Value;
            return gts;
        }
    }
}
