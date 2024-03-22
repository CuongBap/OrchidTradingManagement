using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrchidTradingRepositories.Models.ViewModels;
using OrchidTradingRepositories.Repositories;
using OrchidTradingServices;

namespace OrchidTradingManagement.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;
        readonly private IConfiguration _configuration;

        [BindProperty]
        public Login LoginViewModel { get; set; }

        public LoginModel(IUserService userService, IConfiguration configuration) 
        {
            _userService = userService;
            _configuration = configuration;
        }
        public void OnGet()
        {
        }
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPost(string? ReturnUrl) {
        
            if(ModelState.IsValid)
            {
                var result = await _userService.LoginAsync(LoginViewModel.Username, LoginViewModel.Password);
                if(result == null)
                {
                    IConfiguration config = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();

                    var username = config["AdminAccount:username"];
                    var password = config["AdminAccount:password"];
                    var id = config["AdminAccount:id"];
                    if(username.Equals(LoginViewModel.Username) && password.Equals(LoginViewModel.Password))
                    {
                        HttpContext.Session.SetString("userId", id);
                        HttpContext.Session.SetString("Role", "Admin");
                        return RedirectToPage("Admin/AccessList");
                    }
                    TempData["error"] = "Invalid username or password";
                    return Page();
                }

                HttpContext.Session.SetString("username", LoginViewModel.Username);
                HttpContext.Session.SetString("userId", result.UserId.ToString());
                HttpContext.Session.SetString("Role", result.Role.RoleName);

                return RedirectToPage("index");
            }

             return Page();
                
        }
    }
}
