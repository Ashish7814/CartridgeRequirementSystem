using CartridgeRequirementSystem.Service.Interface;
using Efs.Data;
using Efs.Models;
using Efs.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CartridgeRequirementSystem.Service.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;
        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddOrUpdateCartridgeAsync(CartridgeDetailViewModel model)
        {
            try
            {
                var existingCartridge = await _context.cartridgeDetail
                      .FirstOrDefaultAsync(x => x.printer_brand == model.printer_brand
                                           && x.printer_model == model.printer_model
                                           && x.cartridge_colour == model.cartridge_colour
                                           && x.cartridge_number == model.cartridge_number
                                           && x.cartridge_partNo == model.cartridge_partNo);
                if (existingCartridge != null)
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
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<CartridgeDetailViewModel?> GetCartridgeByIdAsync(int id)
        {
            var details = await _context.cartridgeDetail.FirstOrDefaultAsync(x => x.id == id);
            if (details == null)return null;
            return new CartridgeDetailViewModel
            {
                id = details.id,
                printer_brand = details.printer_brand,
                printer_model = details.printer_model,
                cartridge_colour = details.cartridge_colour,
                cartridge_number = details.cartridge_number,
                cartridge_partNo = details.cartridge_partNo,
                stock_quantity = details.stock_quantity
            };
        }

        public async Task<List<BrandCartridgesViewModel>> GetCartridgesByBrandAsync()
        {
            return await _context.cartridgeDetail
                .GroupBy(c => c.printer_brand)
                .Select(group => new BrandCartridgesViewModel
                {
                    Brand = group.Key,
                    Cartridges = group.ToList(),
                }).ToListAsync();
        }
    }
}
