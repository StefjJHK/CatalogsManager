using System.Collections.Generic;

namespace CatalogsManager.App.Identity.Repositories
{
    public interface IVkAdminsRepository
    {
        IEnumerable<VkAdmin> GetAll();
    }

    public class VkAdmin
    {
        public string Id { get; set; }
    }
}
