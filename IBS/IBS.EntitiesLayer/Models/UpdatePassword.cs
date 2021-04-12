using System;
using System.Collections.Generic;
using System.Text;

namespace IBS.EntitiesLayer.Models
{
    public class UpdatePassword
    {
        public string UserName { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
