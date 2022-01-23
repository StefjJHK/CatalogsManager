using CatalogsManager.App.Identity.Services;
using Microsoft.Extensions.Logging;
using System;

namespace CatalogsManager.Aspects.Logging
{
    public class VkAdminServiceLogging : IVkAdminService
    {
        private IVkAdminService _vkAdminService;
        private readonly ILogger<IVkAdminService> _logger;

        public VkAdminServiceLogging(IVkAdminService vkAdminService, ILogger<IVkAdminService> logger)
        {
            _vkAdminService = vkAdminService ??
                throw new ArgumentNullException(nameof(vkAdminService));
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
        }

        public bool IsUserAdmin(string userId)
        {
            _logger.LogInformation("[{DateTime}] Check is user {UserId} has admin rights.",
                DateTimeOffset.Now, userId);

            var result = _vkAdminService.IsUserAdmin(userId);

            _logger.LogInformation("[{DateTime}] Result checking user {UserId} admin's rights: {IsUserAdmin}",
                DateTimeOffset.Now, userId, result);

            return result;
        }
    }
}
