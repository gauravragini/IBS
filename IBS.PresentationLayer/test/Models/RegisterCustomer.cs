using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBS.PresentationLayer.Models
{
    public class RegisterCustomer
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


        //Nominee details
        public string NomineeName { get; set; }
        public string NomineeRelation { get; set; }
        public int NomineeAge { get; set; }
        public string NomineeGender { get; set; }
        public long? NomineeMobileNumber { get; set; }
        public string NomineeAddress { get; set; }

        //Account details
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public decimal? AvailableBalance { get; set; }
        public decimal? InterestAmount { get; set; }
        public DateTimeOffset? AccountCreationTime { get; set; }

        //for keeping userid
        public string Id { get; set; }
        public string Password { get; set; }
    }
}
