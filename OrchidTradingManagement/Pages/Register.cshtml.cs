using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Models.Enums;
using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Services;

namespace OrchidTradingManagement.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        
        public RegisterModel(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }
        [BindProperty]
        public Register RegisterViewModel { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    Username = RegisterViewModel.Username,
                    Email = RegisterViewModel.Email,
                    Password = RegisterViewModel.Password,
                    Phonenumber = RegisterViewModel.Phonenumber,
                    Status = RegisterViewModel.Status,
                    RoleId = await _roleService.GetRoleId(Role.user.ToString())
                };
                var result = await _userService.AddAsync(user);
                if(result != null)
                {
                    TempData["success"] = "Register successfuly";
                    return RedirectToPage("Login");
                }
                TempData["error"] = "Username existed";
                return Page();
            }
            else
            {
                return Page();
            }
        }
    }
}
