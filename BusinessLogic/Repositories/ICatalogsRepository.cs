using BusinessLogic.DTO;
using System.Collections.Generic;

namespace BusinessLogic.Repositories
{
    public interface ICatalogsRepository
    {
        void Create(CatalogDTO catalogDTO);
        void Update(CatalogDTO catalogDTO);
        void DeleteById(int id);

        IEnumerable<CatalogDTO> GetAll();
        CatalogDTO GetById(int id);
    }
}
