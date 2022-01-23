namespace CatalogsManager.App.Identity.Services
{
    public interface IVkAdminService
    {
        bool IsUserAdmin(string userId);
    }
}
