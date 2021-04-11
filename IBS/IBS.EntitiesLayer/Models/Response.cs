using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBS.EntitiesLayer.Models
{
    public class Response
    {
        public string Status { get; set; }
        public string Message { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string userid { get; set; }

        public string username { get; set; }
        public string userstatus { get; set; }

        public string token { get; set; }

    }
}
