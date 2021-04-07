using System;
using System.Collections.Generic;

#nullable disable

namespace IBS.PresentationLayer.Models
{
    public partial class Adminwork
    {
        public int WorkId { get; set; }
        public string Id { get; set; }
        public DateTime WorkTime { get; set; }
        public string WorkType { get; set; }

       // public virtual AspNetUser IdNavigation { get; set; }
    }
}
