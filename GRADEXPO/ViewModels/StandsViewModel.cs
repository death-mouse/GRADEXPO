﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GRADEXPO.Models;

namespace GRADEXPO.ViewModels
{
    public class StandsViewModel : BaseViewModel
    {

        public int expoId { get; set; }
        public string expoName { get; set; }
        [Display(Name = "ID поставщика")]
        public int vendorId { get; set; }
        [Display(Name = "Наименование поставщика")]
        public string vendorName { get; set; }
        public int standId { get; set; }
        [Display(Name = "описание")]
        public string description { get; set; }
        [Display(Name = "Холл")]
        public string hall { get; set; }
        public int statusId { get; set; }
        public string statusName { get; set; }

        [Display(Name = "Файл импорта")]
        [ValidFileTypeValidator("csv")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public HttpPostedFileBase importFile { get; set; }
        public IEnumerable<VendorFromJson.Vendor> vendrodList { get; set; }
        public IEnumerable<SelectListItem> vendorCombo { get; set; }
    }
}