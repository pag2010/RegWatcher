using System;
using System.Collections.Generic;
using System.Text;

namespace RegWatcher.Data
{
    public class GTS
    {
        public int GTSId { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public int DangerKindId { get; set; }
        public virtual DangerKind DangerKind { get; set; }
        public string Purpose { get; set; }
        public virtual List<SafetyDeclaration> SafetyDeclarations { get; set; }
    }
}
