using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteForPartyGuests.Models
{
    public class Form 
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool? WillAttend { get; set; }

    }
}