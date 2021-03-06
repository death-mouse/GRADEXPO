﻿using System.ComponentModel.DataAnnotations;
using System;


namespace GRADEXPO.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
       
        public Int32 Id { get; set; }

        [Display(Name = "Роль")]
        [ RegularExpression(@"^[a-zA-Zа-яА_Я]*$", ErrorMessage = "Можно указывать только буквы")]
        public int role { get; set; }

        [Display(Name = "Логин")]
        [Required(ErrorMessage = ("Поле логин должно быть заполненно")), RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Можно указывать только латиницу или цифры")]
        public string login { get; set; }

        [Display(Name = "userName")]
        [Required(ErrorMessage = ("Поле логин должно быть заполненно")), RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Можно указывать только латиницу или цифры")]
        public string userName { get; set; }
    }
}