using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MVCPartyInvites.Data;
using MVCPartyInvites.ViewModel;

namespace MVCPartyInvites.Controllers
{
    public class AccountController : Controller
    {
        #region DI

        private PartyContext _context;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        public AccountController(PartyContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            var users = _context.Users;
            var roles = _context.Roles;
            _signInManager = signInManager;
        }

        #endregion DI

        #region Login

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var identityUser = await _userManager.FindByEmailAsync(loginViewModel.Email);
                identityUser.Email = loginViewModel.Email;
                identityUser.UserName = loginViewModel.Email;
                var result = await _signInManager.PasswordSignInAsync(identityUser, loginViewModel.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");   
                }
                else
                {
                    if (result.IsNotAllowed)
                    {
                        ModelState.AddModelError("", "User not allowed!");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cannot login!");
                    }
                }
            }
            return View();
        }

        #endregion Login

        #region Register

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                if (registerViewModel.Password.Equals(registerViewModel.ConfirmPassword))
                {
                    var identityUser = new IdentityUser();
                    identityUser.Email = registerViewModel.Email;
                    identityUser.UserName = registerViewModel.Email;
                    var result = await _userManager.CreateAsync(identityUser, registerViewModel.Password);
                    if (result.Succeeded)
                        return RedirectToAction("Index", "Home");
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Passwoorden komen niet overeen!");
                }
            }
            return View();
        }

        #endregion Register
    }
}