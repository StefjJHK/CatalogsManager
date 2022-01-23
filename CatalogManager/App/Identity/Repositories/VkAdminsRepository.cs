using System.Collections.Generic;

namespace CatalogsManager.App.Identity.Repositories
{
    public class VkAdminsRepository : IVkAdminsRepository
    {
        public IEnumerable<VkAdmin> GetAll()
        {
            return new[]
            {
                new VkAdmin() { Id = "643670644" },
                new VkAdmin() { Id = "145824861" }
            };
        }
    }
}
