using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegWatcher.Models.ViewModels
{
    public class CompanyFilter
    {
        public string Name { get; set; }
        [StringLength(12)]
        public string Inn { get; set; }
        [StringLength(9)]
        public string Kpp { get; set; }
        public string Address { get; set; }
        public int? FormKindId { get; set; }
        [StringLength(15)]
        public string Ogrn { get; set; }
        public string BusinessSubject { get; set; }
    }
}
