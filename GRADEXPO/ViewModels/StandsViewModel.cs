using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRADEXPO.ViewModels
{
    public class StandsViewModel
    {
        public string Title { get; set; }
        public string AddButtonTitle { get; set; }
        public string RedirectUrl { get; set; }


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