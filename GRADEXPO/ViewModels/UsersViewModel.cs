using System.ComponentModel.DataAnnotations;
using System;


namespace GRADEXPO.ViewModels
{
    public class UsersViewModel
    {
        //еуые 2017
        public string Title { get; set; }
        public string AddButtonTitle { get; set; }
        public string RedirectUrl { get; set; }

        public Int32 Id { get; set; }

        [Display(Name = "Роль")]
        [ RegularExpression(@"^[a-zA-Zа-яА_Я]*$", ErrorMessage = "Можно указывать только буквы")]
        public string role { get; set; }

        [Display(Name = "Логин")]
        [Required(ErrorMessage = ("Поле логин должно быть заполненно")), RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Можно указывать только латиницу или цифры")]
        public string login { get; set; }

        [Display(Name = "userName")]
        [Required(ErrorMessage = ("Поле логин должно быть заполненно")), RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Можно указывать только латиницу или цифры")]
        public string userName { get; set; }
    }
}