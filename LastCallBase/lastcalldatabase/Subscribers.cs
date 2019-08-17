using System;
using System.Collections.Generic;

namespace LastCallBase.LastCallDatabase
{
    public partial class Subscribers
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Friendlyname { get; set; }
        public string Phone { get; set; }
        public string Deliveryaddress { get; set; }
        public byte? Emailoffers { get; set; }
        public byte? Textoffers { get; set; }
        public byte? Onmailinglist { get; set; }
        public string Password { get; set; }
    }
}
