using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using DataAccessLayer;
using WebApiService.Repository;

namespace WebApiService.Controllers
{
    public class ContactController : ApiController
    {
        [Route("Contact/GetAllContacts")]
        [HttpGet]
        public JsonResult<List<Models.Contact>> GetAllContacts()
        {
            EntityMapper<DataAccessLayer.Contact, Models.Contact> mapObj = new EntityMapper<DataAccessLayer.Contact, Models.Contact>();
            List<DataAccessLayer.Contact> contactList = DAL.GetAllContacts();
            List<Models.Contact> contacts = new List<Models.Contact>();
            foreach (var item in contactList)
            {
                contacts.Add(mapObj.Translate(item));
            }
            return Json<List<Models.Contact>>(contacts);
        }
        [Route("Contact/GetContact")]
        [HttpGet]
        public JsonResult<Models.Contact> GetContact(int id)
        {
            EntityMapper<DataAccessLayer.Contact, Models.Contact> mapObj = new EntityMapper<DataAccessLayer.Contact, Models.Contact>();
            DataAccessLayer.Contact dalContact = DAL.GetContact(id);
            Models.Contact contacts = new Models.Contact();
            contacts = mapObj.Translate(dalContact);
            return Json<Models.Contact>(contacts);
        }
        [Route("Contact/InsertContact")]
        [HttpPost]
        public bool InsertContact(Models.Contact contact)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapper<Models.Contact, DataAccessLayer.Contact> mapObj = new EntityMapper<Models.Contact, DataAccessLayer.Contact>();
                DataAccessLayer.Contact contactObj = new DataAccessLayer.Contact();
                contactObj = mapObj.Translate(contact);
                status = DAL.InsertContact(contactObj);
            }
            return status;

        }
        [Route("Contact/UpdateContact")]
        [HttpPut]
        public bool UpdateContact(Models.Contact contact)
        {
            EntityMapper<Models.Contact, DataAccessLayer.Contact> mapObj = new EntityMapper<Models.Contact, DataAccessLayer.Contact>();
            DataAccessLayer.Contact contactObj = new DataAccessLayer.Contact();
            contactObj = mapObj.Translate(contact);
            var status = DAL.UpdateContact(contactObj);
            return status;

        }
        [Route("Contact/DeleteContact")]
        [HttpDelete]
        public bool DeleteContact(int id)
        {
            var status = DAL.DeleteContact(id);
            return status;
        }
    }
}