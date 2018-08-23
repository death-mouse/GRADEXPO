
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GRADEXPO.ViewModels
{
    public class LoginViewModel
    {
        [Required, AllowHtml]
        public string Username { get; set; }

        [Required]
        [AllowHtml]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}