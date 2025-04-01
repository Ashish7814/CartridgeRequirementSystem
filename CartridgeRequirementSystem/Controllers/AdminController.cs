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
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
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
                if(user == null && user.department == "Admin")
                {
                    return RedirectToAction("Login", "Account");
                }
                var cartridge = await _context.cartridgeDetail
                    .GroupBy(c => c.printer_brand)
                    .Select(group => new BrandCartridgesViewModel
                    {
                        Brand = group.Key,
                        Cartridges = group.ToList(),
                    }).ToListAsync();
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
                if (ModelState.IsValid)
                {
                    var existingCartridge = await _context.cartridgeDetail
                        .FirstOrDefaultAsync(x => x.printer_brand == model.printer_brand
                                             && x.printer_model == model.printer_model
                                             && x.cartridge_colour == model.cartridge_colour
                                             && x.cartridge_number == model.cartridge_number
                                             && x.cartridge_partNo == model.cartridge_partNo);

                    if(existingCartridge != null)
                    {
                        existingCartridge.stock_quantity += model.stock_quantity;
                        existingCartridge.updatedAt = DateTime.UtcNow;
                        _context.cartridgeDetail.Update(existingCartridge);
                    }
                    else
                    {
                        var cartridge = new CartridgeDetail
                        {
                            id = model.id,
                            printer_brand = model.printer_brand,
                            printer_model = model.printer_model,
                            cartridge_colour = model.cartridge_colour,
                            cartridge_number = model.cartridge_number,
                            cartridge_partNo = model.cartridge_partNo,
                            stock_quantity = model.stock_quantity,
                            createdAt = DateTime.UtcNow
                        };
                        _context.cartridgeDetail.Add(cartridge);
                    }
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Admin");
                }
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
                var details = await _context.cartridgeDetail.FirstOrDefaultAsync(x => x.id == id);
                if(details == null)
                {
                    return NotFound("Data not found.");
                }
                var cartridge = new CartridgeDetailViewModel
                {
                    id = details.id,
                    printer_brand = details.printer_brand,
                    printer_model = details.printer_model,
                    cartridge_colour = details.cartridge_colour,
                    cartridge_number = details.cartridge_number,
                    cartridge_partNo = details.cartridge_partNo,
                    stock_quantity = details.stock_quantity
                };
                return View("CartridgeDetail", cartridge);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "An error occurred: " + ex.Message);
                return View();
            }
        }

      


    }
}
