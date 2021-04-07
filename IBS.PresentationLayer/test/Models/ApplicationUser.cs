using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBS.PresentationLayer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public DateTime Dob { get; internal set; }
        public string Gender { get; internal set; }
        public string FathersName { get; internal set; }
        public string MothersName { get; internal set; }
        public string Address { get; internal set; }
        public int? Pincode { get; internal set; }
        public string Status { get; internal set; }

        public int? UniqueNo { get;  }
    }
}
