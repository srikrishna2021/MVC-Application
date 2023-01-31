using ConsumeWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ConsumeWebApi.Controllers
{

    public class ContactController : Controller
    {
        // GET: Product  
        public ActionResult GetAllContacts()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("Contact/GetAllContacts");
                response.EnsureSuccessStatusCode();
                List<Models.Contact> contacts = response.Content.ReadAsAsync<List<Models.Contact>>().Result;
                ViewBag.Title = "All Contacts";
                return View(contacts);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //[HttpGet]  
        public ActionResult EditContact(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("Contact/GetContact?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.Contact contacts = response.Content.ReadAsAsync<Models.Contact>().Result;
            ViewBag.Title = "All Contacts";
            return View(contacts);
        }
        //[HttpPost]  
        public ActionResult Update(Models.Contact contact)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("Contact/UpdateContact", contact);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllContacts");
        }
        public ActionResult Details(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("Contact/GetContact?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.Contact contacts = response.Content.ReadAsAsync<Models.Contact>().Result;
            ViewBag.Title = "All Products";
            return View(contacts);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.Contact contact)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("Contact/InsertContact", contact);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllContacts");
        }
        public ActionResult Delete(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("Contact/DeleteContact?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllContacts");
        }
    }

}