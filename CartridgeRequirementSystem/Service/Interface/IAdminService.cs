using Efs.Data;
using Efs.ViewModels;

namespace CartridgeRequirementSystem.Service.Interface
{
    public interface IAdminService
    {
        Task<List<BrandCartridgesViewModel>> GetCartridgesByBrandAsync();
        Task<CartridgeDetailViewModel?> GetCartridgeByIdAsync(int id);
        Task<bool> AddOrUpdateCartridgeAsync(CartridgeDetailViewModel model);
    }
}
