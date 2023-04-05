using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.UI.WebControls;
using Theatre.Service.Common;
using Theatre.Service;
using Theatre.Repository;
using Theatre.Model;
using Theatre.Common;

namespace Theatre.WebApi.Controllers
{
    public class PersonnelController : ApiController
    {
        protected IPersonnelService PersonnelService { get; set; }

        public PersonnelController(IPersonnelService personnelService)
        {
            PersonnelService = personnelService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetAllPersonnelAsync(Paging paging, Sorting sorting, Filtering filtering)
        {
            var worker = await PersonnelService.GetAllPersonnelAsync(paging, sorting, filtering);
            if (worker != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, worker);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Details Have Not Been Found! Try again!");
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetPersonnelAsync(Guid id)
        {
            var personnel = await PersonnelService.GetPersonnelAsync(id);
            if (personnel != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, personnel);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Try again! Personnel has not been found!");
            }
        }


        [HttpPost]
        public async Task<HttpResponseMessage> AddPersonnelAsync(PersonnelRest personnel)
        {
            Personnel person = new Personnel();
            person.Id = personnel.Id;
            person.PersonnelName = personnel.PersonnelName;
            person.Surname = personnel.Surname;
            person.Position = personnel.Position;
            person.HoursOfWork = personnel.HoursOfWork;

            bool newPersonnel = await PersonnelService.AddPersonnelAsync(person);
            if (newPersonnel != false)
            {
                return Request.CreateResponse(HttpStatusCode.Accepted, "Add Buyer completed.");
            }

            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Try again!");
            }

        }
        [HttpPut]
        public async Task<HttpResponseMessage> EditPersonnelAsync(Guid id, [FromBody] PersonnelRest personnel)
        {
            Personnel putPersonnel = new Personnel();
            putPersonnel.PersonnelName = putPersonnel.PersonnelName;
            putPersonnel.Surname=putPersonnel.Surname;
            putPersonnel.Position = putPersonnel.Position;
            putPersonnel.HoursOfWork = putPersonnel.HoursOfWork;

            bool putSucces = await PersonnelService.EditPersonnelAsync(id, putPersonnel);
            if (putSucces != false)

            {
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully updated");
            }
            else
                    
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Update Failed, Try Again!");
            }
        }
        [HttpDelete]
        public async Task<HttpResponseMessage> DeletePersonnelAsync(Guid id)
        {
                bool personnel = await PersonnelService.DeletePersonnelAsync(id);
                if (personnel != false)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, $"Personnel with Id {id} has been deleted.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, $"Personnel with Id {id} has not been found.");
                }
        }
    }
}