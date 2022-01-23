using CatalogsManager.App.Identity.Requirements;
using CatalogsManager.App.Identity.Services;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CatalogsManager.App.Identity.RequirementHandlers
{
    public class VkAdminHandler : AuthorizationHandler<AllowedEditCatalogsRequirement>
    {
        private readonly IVkAdminService _vkAdminService;

        public VkAdminHandler(IVkAdminService vkAdminService)
        {
            _vkAdminService = vkAdminService ??
                throw new ArgumentNullException(nameof(vkAdminService));
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AllowedEditCatalogsRequirement requirement)
        {
            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isUserAdmin = _vkAdminService.IsUserAdmin(userId);

            if (isUserAdmin)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
