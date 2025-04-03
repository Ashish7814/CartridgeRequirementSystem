using CartridgeRequirementSystem.Service.Interface;
using Efs.Data;
using Efs.Models;
using Efs.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CartridgeRequirementSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IAdminService _adminService;
        public AdminController(ApplicationDbContext context, IAdminService adminService)
        {
            _context = context;
            _adminService = adminService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var userEmail = HttpContext.Session.GetString("UserEmail");
                var userDepartment = HttpContext.Session.GetString("UserDepartment");
                if(string.IsNullOrEmpty(userEmail) || string.IsNullOrEmpty(userDepartment))
                {
                    return RedirectToAction("Login", "Account");
                }
                var user = await _context.users.FirstOrDefaultAsync(u => u.email == userEmail && u.department == userDepartment);
                if(user == null && user.department != "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                var cartridge = await _adminService.GetCartridgesByBrandAsync();
                return View(cartridge);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "An error occurred: " + ex.Message);
                return View();
            }

        }

        [HttpGet]
        public IActionResult AddCartridge()
        {
            return View("AddCartridge", new CartridgeDetailViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddCartridge(CartridgeDetailViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var result = await _adminService.AddOrUpdateCartridgeAsync(model);
                if (result)
                {
                    return RedirectToAction("Index", "Admin");
                }
                ModelState.AddModelError("", "Failed to add cartridge.");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "An error occurred: " + ex.Message);
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CartridgeDetail(int id)
        {
            try
            {
                if(id == null)
                {
                    return NotFound("Data not found.");
                }
                var cartridge = await _adminService.GetCartridgeByIdAsync(id);
                if (cartridge == null)
                {
                    return NotFound("Data not found.");
                }
                return View("CartridgeDetail", cartridge);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "An error occurred: " + ex.Message);
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> ManageCartridge()
        {
            var cartridges = await _adminService.ManageCartridgeAsync();
            return View("ManageCartridge", cartridges);
        }

    }
}
