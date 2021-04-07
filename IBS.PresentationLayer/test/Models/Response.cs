using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBS.PresentationLayer.Models
{
    public class Response
    {
        public string Status { get; set; }
        public string Message { get; set; }

        public string token { get; set; }
        public string ValidTo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string userid { get; set; }


    }
}
