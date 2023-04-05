using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theatre.Common;
using Theatre.Model;
using Theatre.Repository;
using Theatre.Repository.Common;
using Theatre.Service.Common;

namespace Theatre.Service
{
    public class PersonnelService : IPersonnelService
    {
        protected IPersonnelRepository PersonnelRepository { get; set; }

        public PersonnelService(IPersonnelRepository personnelRepository)
        {
            PersonnelRepository = personnelRepository;
        }

        public async Task<List<Personnel>> GetAllPersonnelAsync(Paging paging, Sorting sorting, Filtering filtering)
        {
            List<Personnel> worker = await PersonnelRepository. GetAllPersonnelAsync(paging, sorting, filtering);
            return worker;
        }

        public async Task<Personnel>GetPersonnelAsync(Guid id)
        {
            Personnel personnel = await PersonnelRepository. GetPersonnelAsync(id);
            return personnel;
        }

        public async Task<bool> AddPersonnelAsync(Personnel personnel)
        {
            bool newPersonnel = await PersonnelRepository.AddPersonnelAsync(personnel);
            return newPersonnel;
        }
        public async Task<bool> EditPersonnelAsync(Guid id,  Personnel personnel)
        {
            bool edited = await PersonnelRepository.AddPersonnelAsync(personnel);
            return edited;
        }
        public async Task<bool> DeletePersonnelAsync(Guid id)
        {
            bool personnel = await PersonnelRepository.DeletePersonnelAsync(id);
            return true;
        }
    }
}
