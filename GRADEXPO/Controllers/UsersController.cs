using System.Threading.Tasks;
using System.Web.Mvc;
using GRADEXPO.Services;
using GRADEXPO.ViewModels;
using GRADEXPO.Models;
using System;


namespace GRADEXPO.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService userService;
        public UsersController(IUsersService _userService)
        {
            userService = _userService;
        }

        public async Task<ActionResult> Index()
        {
            var usersModels = await userService.GetUsersAsync();

            return View(usersModels);
        }

        public ActionResult AddUsers()
        {
            var usersViewModel = new UsersViewModel
            {
                Title = "Добавление нового пользователя",
                AddButtonTitle = "Создать",
                RedirectUrl = Url.Action("Index", "Users")
            };

            return View(usersViewModel);
        }

        
        public async Task<ActionResult> DetailsOfUser(int Id)
        {
            var users = await userService.GetUserAsync(Id);

            return View(new UsersViewModel { Id = users.userId, login = users.login, userName = users.userName, role = users.role });
        }

        [HttpPost]
        public async Task<ActionResult> SaveUser(UsersViewModel _userViewModel, string _redirectUrl)
        {
            if(!ModelState.IsValid)
            {
                return View(_userViewModel);
            }

            var user = await userService.GetUserAsync(_userViewModel.Id);
            if(user != null)
            {
                user.userName = _userViewModel.userName;
                user.role = _userViewModel.role;
                user.login = _userViewModel.login;
                await userService.UpdateUserAsync(user);
            }

            return RedirectToLocal(_userViewModel.RedirectUrl);
        }


        public async Task<ActionResult> EditUser(int Id)
        {
            var user = await userService.GetUserAsync(Id);
            var userViewModel = new UsersViewModel
            {
                Title = "Изменение пользователя",
                AddButtonTitle = "Сохранить",
                RedirectUrl = Url.Action("Index", "Users"),
                login = user.login,
                userName = user.userName,
                Id = user.userId,
                role = user.role
            };

            return View(userViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> AddNewUser(UsersViewModel _userViewModel, string redirectUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(_userViewModel);
            }

            var user = new Users
            {
                userName = _userViewModel.userName,
                role = _userViewModel.role,
                login = _userViewModel.login
            };

            await userService.AddUserAsync(user);

            return RedirectToLocal(redirectUrl);
        }
        public async Task<ActionResult> DeleteUser(int id)
        {
            await userService.DeleteUserAsync(id);

            return RedirectToAction("Index");
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Users");
        }
    }

}