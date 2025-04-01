using CartridgeRequirementSystem.Service.Interface;
using Efs.Data;
using Efs.Models;
using Efs.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CartridgeRequirementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IAccountService _accountService;
        public AccountController(ApplicationDbContext context, IAccountService accountService)
        { 
            _context = context;
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserEmail") != null)
            {
                return RedirectToAction(nameof(SignUp));
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(login.email) || string.IsNullOrWhiteSpace(login.password))
                    {
                        ModelState.AddModelError("", "Email and Password are required.");
                        return View(login);
                    }
                    var user = await _accountService.LoginAsync(login);
                    if (user == null)
                    {
                        ModelState.AddModelError("", "Invalid login attempt.");
                        return View(login);
                    }

                    HttpContext.Session.SetString("UserEmail", login.email);
                    HttpContext.Session.SetString("UserDepartment", user.department);

                    if (user.department.ToLower() == "admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "User");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred: " + ex.Message);
                    return View(login);
                }
            }
            return View(login);
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return View(model);
                }
                var result = await _accountService.RegisterAsync(model);
                if (!result)
                {
                    ModelState.AddModelError("Email", "This email is already registered.");
                    return View(model);
                }
                return RedirectToAction(nameof(SignUp));

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred: " + ex.Message);
                return View(model);
            }
        }
    }
}
