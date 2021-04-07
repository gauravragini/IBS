using System;
using System.Collections.Generic;

#nullable disable

namespace IBS.EntitiesLayer.Models
{
    public partial class Adminwork
    {
        public int WorkId { get; set; }
        public string Id { get; set; }
        public DateTime WorkTime { get; set; }
        public string WorkType { get; set; }
    }
}
