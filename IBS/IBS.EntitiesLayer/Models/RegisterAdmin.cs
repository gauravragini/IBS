using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBS.EntitiesLayer.Models
{
    public class RegisterAdmin
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public string Address { get; set; }
        public int? Pincode { get; set; }
        public string Status { get; set; }
        public string Password { get; set; }
    }
}
