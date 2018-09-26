using GRADEXPO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GRADEXPO.ViewModels
{
    public class PlanVisitViewModel : BaseViewModel
    {
        public DateTime start { get; set; }
        public int type { get; set; }

        public int expoId { get; set; }
        [Display(Name = "Комментарий")]
        public string Comments { get; set; }
        public int standId { get; set; }
        public int planVisitId { get; set; }
        public int vendorId { get; set; }
        [Display(Name = "Дата и время посещения")]
        public DateTime planvisitDateTime { get; set; }
        [Display(Name ="Список пользователей")]
        public string userListLable { get; set; }

    }
}