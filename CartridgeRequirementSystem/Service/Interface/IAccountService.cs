using Efs.ViewModels;

namespace CartridgeRequirementSystem.Service.Interface
{
    public interface IAccountService
    {
        Task<UserViewModel?> LoginAsync(LoginViewModel login);
        Task<bool> RegisterAsync(UserViewModel model);
    }
}
