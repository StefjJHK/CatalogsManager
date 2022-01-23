using CatalogsManager.App.Identity.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CatalogsManager.App.Identity.Services
{
    public class VkAdminService : IVkAdminService
    {
        private readonly IVkAdminsRepository _adminsRepository;
        private readonly DbSet<IdentityUserLogin<string>> _userLogins;

        public VkAdminService(IVkAdminsRepository adminsRepository, DbSet<IdentityUserLogin<string>> userLogins)
        {
            _adminsRepository = adminsRepository ??
                throw new ArgumentNullException(nameof(adminsRepository));
            _userLogins = userLogins ??
                throw new ArgumentNullException(nameof(userLogins));
        }

        public bool IsUserAdmin(string userId)
        {
            var userLogin = _userLogins
                .FirstOrDefault(userLogin => userLogin.UserId == userId);
            var userLogins = _userLogins.Select(value => value).ToList();

            return _adminsRepository
                .GetAll()
                .Any(admin => admin.Id.Equals(userLogin?.ProviderKey));
        }
    }
}
