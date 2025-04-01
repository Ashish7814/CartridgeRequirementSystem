using CartridgeRequirementSystem.Service.Interface;
using Efs.Data;
using Efs.Models;
using Efs.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CartridgeRequirementSystem.Service.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        public AccountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserViewModel?> LoginAsync(LoginViewModel login)
        {
            var user = await _context.users
                .FirstOrDefaultAsync(x => x.email == login.email 
                && x.password == login.password);
            if(user == null)
            {
                return null;
            }
            return new UserViewModel
            {
                email = user.email,
                user_name = user.user_name,
                department = user.department,
            };
        }

        public async Task<bool> RegisterAsync(UserViewModel model)
        {
            var emailExists = await _context.users.AnyAsync(r => r.email == model.email);
            if (emailExists)
            {
                return false;
            }
            var user = new User
            {
                user_name = model.user_name,
                email = model.email,
                department = model.department,
                password = model.password,
            };
            _context.users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
