using System.ComponentModel.DataAnnotations;
using System;
using System.Web;
using System.Collections.Generic;

namespace GRADEXPO.ViewModels
{
    public class ExposViewModel
    {
        public string Title { get; set; }
        public string AddButtonTitle { get; set; }
        public string RedirectUrl { get; set; }

        public Int32 Id { get; set; }

        [Display(Name = "Название выставки")]
        [MaxLength(50, ErrorMessage = "Превышена допустима длина строки")]
        public string ExpoName { get; set; }

        [Display(Name = "Дата начала выставки")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime DateStart { get; set; }

        [Display(Name = "Дата окончания выставки")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime DateEnd { get; set; }

        [Display(Name = "Описание выставки")]
        [DataType(DataType.Text)]
        public string Description { get; set; }


        [Display(Name = "Логотип выставки")]
        [ValidFileTypeValidator("jpg, jpeg, gif")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public HttpPostedFileBase logoFile { get; set; }

        public List<Models.Stands> Stands { get; set; }
        public List<Models.VisitFromJson.Visit> Visit { get; set; }
        public List<Models.PlanVisitFromjson.PlanVisit> PlanVisits { get; set; }
    }
}