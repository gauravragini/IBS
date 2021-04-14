using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace IBS.EntitiesLayer.Models
{
    public partial class Adminwork
    {
        [Key]
        public int WorkId { get; set; }
        public string ID { get; set; }
        public DateTime WorkTime { get; set; }
        public string WorkType { get; set; }
    }
}
