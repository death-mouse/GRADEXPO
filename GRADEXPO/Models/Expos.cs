using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace GRADEXPO.Models
{
    [Table("Expo")]
    public class Expos
    {
        [Key]
        public int Id { get; set; }
        public string ExpoName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}