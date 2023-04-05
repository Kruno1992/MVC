using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Theatre.Common;
using Theatre.DAL;
using Theatre.Repository.Common;

namespace EFPersonnel.Repository
{
    public class EFPersonnelRepository : IPersonnelRepository
    {
        private readonly TheatreContext _context;
        public EFPersonnelRepository(TheatreContext context)
        {
            _context = context;
        }
        public async Task<bool> AddPersonnelAsync(Theatre.Model.Personnel personnel)
        {
            try
            {
                _context.Personnel.Add(new Theatre.DAL.Personnel
                {
                    Id = personnel.Id,
                    PersonnelName = personnel.PersonnelName,
                    Surname = personnel.Surname,
                    HoursOfWork = personnel.HoursOfWork
                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeletePersonnelAsync(Guid id)
        {
            try
            {
                Personnel personnelDEL = await _context.Personnel.FindAsync(id);
                if (personnelDEL == null)
                {
                    return false;
                }

                _context.Personnel.Remove(personnelDEL);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> EditPersonnelAsync(Guid id, Theatre.Model.Personnel personnel)
        {
            try
            {
                Personnel personnelEdit = await _context.Personnel.FindAsync(id);
                if (personnelEdit == null)
                {
                    return false;
                }

                personnelEdit.PersonnelName = personnel.PersonnelName;
                personnelEdit.Surname = personnel.Surname;
                personnelEdit.Position = personnel.Position;
                personnelEdit.HoursOfWork = personnel.HoursOfWork;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Theatre.Model.Personnel>> GetAllPersonnelAsync(Paging paging, Sorting sorting, Filtering filtering)
        {
            try
            {
                IQueryable<Personnel> query = _context.Personnel.AsQueryable();
                if (filtering != null)
                {
                    if (filtering.Id != null)
                    {
                        query = query.Where(e => e.Id == filtering.Id);
                    }
                }
                if (sorting != null)
                {
                    if (sorting.OrderBy.Equals("Id"))
                    {
                        query = query.OrderBy(e => e.Id);
                    }
                    else if (sorting.OrderBy.Equals("PersonnelName"))
                    {
                        query.OrderBy(e => e.PersonnelName);
                    }
                    else if (sorting.OrderBy.Equals("Surname"))
                    {
                        query.OrderBy(e => e.Surname);
                    }
                }

                if (paging != null && paging.PageNumber > 0)
                {
                    int skipCount = (int)((paging.PageNumber - 1) * paging.PageSize);
                    query = query.Skip(skipCount).Take((int)paging.PageSize);
                }

                List<Theatre.Model.Personnel> personnel = await _context.Personnel.Select(s => new Theatre.Model.Personnel()
                {
                    Id = s.Id,
                    PersonnelName = s.PersonnelName,
                    Surname = s.Surname,
                    HoursOfWork = s.HoursOfWork.Value,
                }).ToListAsync();

                return personnel;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Theatre.Model.Personnel> GetPersonnelAsync(Guid id)
        {
            try
            {
                Personnel personID = await _context.Personnel.FindAsync(id);

                Theatre.Model.Personnel worker = new Theatre.Model.Personnel
                {
                    Id = personID.Id,
                    PersonnelName = personID.PersonnelName,
                    Surname = personID.Surname,
                    HoursOfWork = personID.HoursOfWork.Value,
                };

                if (personID != null)
                {
                    return worker;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
