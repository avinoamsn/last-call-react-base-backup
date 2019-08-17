using System;
using System.Collections.Generic;

namespace LastCallBase.LastCallDatabase
{
    public partial class Suppliers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public byte[] Logo { get; set; }
        public string Url { get; set; }
        public string Mapurl { get; set; }
        public string NewTablecol { get; set; }
    }
}
