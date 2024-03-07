using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models;
using OrchidTradingRepositories.Models.Enums;
using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Repositories;

namespace OrchidTradingManagement.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        
        public RegisterModel(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
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
                    RoleId = await _roleRepository.GetRoleId(Role.user.ToString())
                };
                var result = await _userRepository.AddAsync(user);
                if(result != null)
                {
                    return RedirectToPage("Login");
                }
                return Page();
            }
            else
            {
                return Page();
            }
        }
    }
}
