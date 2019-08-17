using System;
using System.Collections.Generic;

namespace LastCallBase.LastCallDatabase
{
    public partial class Tbloffers
    {
        public int Id { get; set; }
        public DateTime? Offerdate { get; set; }
        public DateTime? Offerstarttime { get; set; }
        public DateTime? Offerendtime { get; set; }
        public string Offername { get; set; }
        public string Offerdescription { get; set; }
        public int? Supplier { get; set; }
        public int? Qtyavailable { get; set; }
        public int? Foodtype { get; set; }
    }
}
