using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GRADEXPO.Models
{
    [Table("Stand")]
    public class Stands
    {
        [Key]
        public int expoId { get; set; }
        public string expoName { get; set; }
        public int vendorId { get; set; }
        public string vendorName { get; set; }
        public int standId { get; set; }
        public string description { get; set; }
        public string hall { get; set; }
        public int statusId { get; set; }
        public string statusName { get; set; }
    }
}