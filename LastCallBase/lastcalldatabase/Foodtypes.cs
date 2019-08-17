using System;
using System.Collections.Generic;

namespace LastCallBase.LastCallDatabase
{
    public partial class Foodtypes
    {
        public Foodtypes()
        {
            Foodpreferences = new HashSet<Foodpreferences>();
        }

        public int Id { get; set; }
        public string Foodtype { get; set; }

        public ICollection<Foodpreferences> Foodpreferences { get; set; }
    }
}
