using System;
using System.Collections.Generic;

#nullable disable

namespace IBS.PresentationLayer.Models
{
    public partial class Nominee
    {
        public int NomineeId { get; set; }
        public string NomineeName { get; set; }
        public string NomineeRelation { get; set; }
        public int NomineeAge { get; set; }
        public string NomineeGender { get; set; }
        public long? NomineeMobileNumber { get; set; }
        public string NomineeAddress { get; set; }
        public string Id { get; set; }

      //  public virtual AspNetUser IdNavigation { get; set; }
    }
}
