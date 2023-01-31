using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class DAL
    {
        static ContactDBContext DbContext;
        static DAL()
        {
            DbContext = new ContactDBContext();
        }
        public static List<Contact> GetAllContacts()
        {
            return DbContext.Contact.ToList();
        }
        public static Contact GetContact(int contactId)
        {
            return DbContext.Contact.Where(p => p.Id == contactId).FirstOrDefault();
        }
        public static bool InsertContact(Contact contactItem)
        {
            bool status;
            try
            {
                DbContext.Contact.Add(contactItem);
                DbContext.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public static bool UpdateContact(Contact contactItem)
        {
            bool status;
            try
            {
                Contact contItem = DbContext.Contact.Where(p => p.Id == contactItem.Id).FirstOrDefault();
                if (contItem != null)
                {
                    contItem.FirstName = contactItem.FirstName;
                    contItem.LastName = contactItem.LastName;
                    contItem.Email = contactItem.Email;
                    contItem.PhoneNumber= contactItem.PhoneNumber;
                    contItem.Address = contactItem.Address;
                    contItem.City = contactItem.City;
                    contItem.State= contactItem.State;
                    contItem.Country = contactItem.Country;
                    contItem.PostalCode= contactItem.PostalCode;
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public static bool DeleteContact(int contactId)
        {
            bool status;
            try
            {
                Contact contItem = DbContext.Contact.Where(p => p.Id == contactId).FirstOrDefault();
                if (contItem != null)
                {
                    DbContext.Contact.Remove(contItem);
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}
