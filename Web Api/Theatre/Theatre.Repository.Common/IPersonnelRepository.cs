using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theatre.Common;
using Theatre.Model;

namespace Theatre.Repository.Common
{
    public interface IPersonnelRepository
    {
        Task<List<Model.Personnel>> GetAllPersonnelAsync(Paging paging, Sorting sorting, Filtering filtering);
        Task<Theatre.Model.Personnel> GetPersonnelAsync(Guid id);
        Task<bool> AddPersonnelAsync(Personnel personnel);
        Task<bool> EditPersonnelAsync(Guid id, Personnel personnel);
        Task<bool> DeletePersonnelAsync(Guid id);
    }
}
