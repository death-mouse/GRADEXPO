using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace GRADEXPO.Models
{
    [Table("Expo")]
    public class Expos
    {
        [Key]
        [Display(Name = "Ид Выставки")]
        public int expoId { get; set; }
        [Display(Name = "Название выставки")]
        public string expoName { get; set; }
        [Display(Name = "Начало выставки")]
        public DateTime startDate { get; set; }
        [Display(Name = "Окончание выставки")]
        public DateTime endDate { get; set; }
        [Display(Name = "Описание выставки")]
        public string description { get; set; }
    }
}