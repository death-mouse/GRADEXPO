using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GRADEXPO.ViewModels
{
    public class VendorContactViewModel : BaseViewModel
    {
        [Display(Name = "Мессанджер")]
        public string im { get; set; }
        public Int32 contactId { get; set; }
        [Display(Name = "Телефон")]
        [RegularExpression(@"^([0-9+])+$", ErrorMessage = "Введите корректный телефон. Вводить можно только цифры и +")]
        public string phone { get; set; }
        [Display(Name = "Должность")]
        public string contactPosition { get; set; }
        [Display(Name = "ФИО")]
        public string contactPerson { get; set; }
        [Display(Name = "Описание")]
        public string description { get; set; }
        public Int32 vendorId { get; set; }
        [Display(Name = "EMail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Введите корректный E-mail")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Введите корректный E-mail")]
        public string email { get; set; }
    }
}