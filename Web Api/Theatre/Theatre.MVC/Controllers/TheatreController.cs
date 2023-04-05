using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Theatre.Service.Common;
using Theatre.Common;
using Theatre.MVC.Models;
using Theatre.Model;
using System.Web.UI.WebControls;

namespace Theatre.MVC.Controllers
{
    public class PersonnelController : Controller
    {
        protected IPersonnelService PersonnelService { get; set; }

        public PersonnelController(IPersonnelService personnelService)
        {
            PersonnelService = personnelService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPersonnelAsync(Paging paging, Sorting sorting, Filtering filtering)
        {
            var workers = await PersonnelService.GetAllPersonnelAsync(paging, sorting, filtering);
            List<PersonnelView> listView = new List<PersonnelView>();
            if (workers != null)
            {
                foreach (var worker in workers)
                {
                    PersonnelView view = new PersonnelView();
                    view.Id = worker.Id;
                    view.PersonnelName = worker.PersonnelName;
                    view.Surname = worker.Surname;
                    view.HoursOfWork = worker.HoursOfWork;
                    listView.Add(view);
                }
                return View(listView);
            }
            else
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetPersonnelAsync(Guid id)
        {
            var worker = await PersonnelService.GetPersonnelAsync(id);
            if (worker == null)
            {
                return View("Error");
            }

            PersonnelView workerId = new PersonnelView
            {
                Id = worker.Id,
                PersonnelName = worker.PersonnelName,
                Surname = worker.Surname,
                Position = worker.Position,
                HoursOfWork = worker.HoursOfWork
            };

            return View(workerId);
        }

        [HttpGet]
        public ActionResult AddPersonnelAsync()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddPersonnelAsync(PersonnelView personnel)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            Personnel addPersonnel = new Personnel
            {
                Id = Guid.NewGuid(),
                PersonnelName = personnel.PersonnelName,
                Surname = personnel.Surname,
                Position = personnel.Position,
                HoursOfWork = personnel.HoursOfWork
            };

            bool complete = await PersonnelService.AddPersonnelAsync(addPersonnel);
            if (!complete)
            {
                return View("Error");
            }
            return RedirectToAction("GetAllPersonnelAsync");
        }

        [HttpGet]
        public async Task<ActionResult> EditPersonnelAsync(Guid id)
        {
            Personnel worker = await PersonnelService.GetPersonnelAsync(id);
            if (worker == null)
            {
                return View("Error");
            }

            PersonnelView workerView = new PersonnelView
            {
                Id = worker.Id,
                PersonnelName = worker.PersonnelName,
                Surname = worker.Surname,
                Position = worker.Position,
                HoursOfWork = worker.HoursOfWork
            };
            return View(workerView);
        }

        [HttpPost]
        public async Task<ActionResult> EditPersonnelAsync(Guid id, PersonnelView personnel)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            Personnel editPersonnel = new Personnel
            {
                Id = personnel.Id,
                PersonnelName = personnel.PersonnelName,
                Surname = personnel.Surname,
                Position = personnel.Position,
                HoursOfWork = personnel.HoursOfWork
            };

            bool complete = await PersonnelService.EditPersonnelAsync(id, editPersonnel);
            if (!complete)
            {
                return View("Error");
            }
            return RedirectToAction("GetAllPersonnelAsync");
        }

        [HttpGet]
        public async Task<ActionResult> DeletePersonnelAsync(Guid id)
        {
            Personnel personnel = await PersonnelService.GetPersonnelAsync(id);
            if (personnel == null)
            {
                return View("Error");
            }
            PersonnelView personnelID = new PersonnelView
            {
                PersonnelName = personnel.PersonnelName,
                Surname = personnel.Surname,
                Position = personnel.Position,
                HoursOfWork = personnel.HoursOfWork
            };
            return View(personnelID);
        }

        [HttpPost, ActionName("DeletePersonnelAsync")]

        public async Task<ActionResult> ConfirmationDeletePersonnelAsync(Guid id)
        {
            bool complete = await PersonnelService.DeletePersonnelAsync(id);
            if (!complete)
            {
                return View("Error");
            }
            return RedirectToAction("GetAllPersonnelAsync");
        }

    }
}