using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theatre.Common;
using Theatre.Model;

namespace Theatre.Service.Common
{
    public interface IPersonnelService
    {  
      Task<List<Personnel>> GetAllPersonnelAsync(Paging paging, Sorting sorting, Filtering filtering);
      Task<Personnel> GetPersonnelAsync(Guid id);
      Task<bool> AddPersonnelAsync(Personnel personnel);
      Task<bool> EditPersonnelAsync(Guid id, Personnel personnel);
      Task<bool> DeletePersonnelAsync(Guid id);
    }
}

