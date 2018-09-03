using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GRADEXPO.ViewModels
{
    public class ExposFilesViewModel
    {
        public string Title { get; set; }
        public string AddButtonTitle { get; set; }
        public string RedirectUrl { get; set; }


        public int expoId { get; set; }

        [Display(Name = "Файл выставки")]
        [ValidFileTypeValidator("pdf, doc,docx")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public HttpPostedFileBase file { get; set; }
    }
}