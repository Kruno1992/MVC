using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theatre.DAL;
using Theatre.Repository.Common;

namespace EFPersonnel.Repository
{
    public class EFPersonnelRepository : IPersonnelRepository
    {
        public Task<bool> AddPersonnelAsync(Theatre.Model.Personnel personnel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePersonnelAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditPersonnelAsync(Guid id, Theatre.Model.Personnel personnel)
        {
            throw new NotImplementedException();
        }

        public Task<List<Personnel>> GetAllPersonnelAsync(Theatre.Common.Paging paging, Theatre.Common.Sorting sorting, Theatre.Common.Filtering filtering)
        {
            try
            {
                List<Personnel>
            }
            throw new NotImplementedException();
        }

        public Task<List<Theatre.Model.Personnel>> GetPersonnelAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
