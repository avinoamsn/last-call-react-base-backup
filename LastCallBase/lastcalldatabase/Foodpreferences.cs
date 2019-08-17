using System;
using System.Collections.Generic;

namespace LastCallBase.LastCallDatabase
{
    public partial class Foodpreferences
    {
        public int Id { get; set; }
        public int Subscriberid { get; set; }
        public int Preferenceid { get; set; }

        public Foodtypes Preference { get; set; }
    }
}
