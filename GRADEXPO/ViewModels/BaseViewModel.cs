using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRADEXPO.ViewModels
{
    public class BaseViewModel
    {
        public string Title { get; set; }
        public string AddButtonTitle { get; set; }
        public string RedirectUrl { get; set; }
    }
}