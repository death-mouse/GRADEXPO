using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GRADEXPO.ViewModels
{
    public class ImageViewModel : BaseViewModel
    {

        [Display(Name = "Фотография")]
        [ValidFileTypeValidator("jpg, jpeg, png")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public HttpPostedFileBase photoFile { get; set; }

        public int expoId { get; set; }
    }
}