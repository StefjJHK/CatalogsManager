using BusinessLogic.DTO;
using System.Collections.Generic;

namespace BusinessLogic.Repositories
{
    public interface ITitlesRepository
    {
        void Create(TitleDTO title);
        void Update(TitleDTO title);
        void DeleteById(int id);

        TitleDTO GetById(int id);
        IEnumerable<TitleDTO> GetAll();
    }
}
