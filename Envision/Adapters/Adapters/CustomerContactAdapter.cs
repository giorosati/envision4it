using Envision.Adapters.Interfaces;
using Envision.data;
using Envision.Data.Model;
using Envision.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Envision.Adapters.Adapters
{
    public class CustomerContactAdapter : ICustomerContactAdapter
    {
        public List<AdminCustomerContactVM> GetCustomerContacts()
        {
            List<AdminCustomerContactVM> model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.CustomerContacts.Where(x => x.DateDeleted == null).OrderBy(x => x.Name).Take(20).Select(x => new AdminCustomerContactVM()
                    {
                        CustomerContactID = x.CustomerContactID,
                        Name = x.Name,
                        UserID = x.UserID,
                        Department = x.Department,
                        Title = x.Title,
                        MobileNumber = x.MobileNumber,
                        WorkNumber = x.WorkNumber,
                        FaxNumber = x.FaxNumber,
                        Skype = x.Skype,
                        Email = x.Email
                    }).ToList();
            }
            return model;
        }

        public AdminCustomerContactVM GetCustomerContact(int id)
        {
            AdminCustomerContactVM model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.CustomerContacts.Where(x => x.CustomerContactID == id).Select(x => new AdminCustomerContactVM()
                   {
                       CustomerContactID = x.CustomerContactID,
                       Name = x.Name,
                       UserID = x.UserID,
                       Department = x.Department,
                       Title = x.Title,
                       MobileNumber = x.MobileNumber,
                       WorkNumber = x.WorkNumber,
                       FaxNumber = x.FaxNumber,
                       Skype = x.Skype,
                       Email = x.Email
                   }).FirstOrDefault();
            }
            return model;
        }

        public void EditCustomerContact(AdminCustomerContactVM contact, int id)
        {
            if (contact != null)
            {
                CustomerContact model;
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    model = db.CustomerContacts.FirstOrDefault(x => x.CustomerContactID == id);
                    model.Name = contact.Name;
                    model.UserID = contact.UserID;
                    model.Department = contact.Department;
                    model.Title = contact.Title;
                    model.MobileNumber = contact.MobileNumber;
                    model.WorkNumber = contact.WorkNumber;
                    model.FaxNumber = contact.FaxNumber;
                    model.Skype = contact.Skype;
                    model.Email = contact.Email;
                    db.SaveChanges();
                };
            };
        }

        public AdminCustomerContactVM NewCustomerContact(AdminCustomerContactVM contact)
        {
            if (contact != null)
            {
                CustomerContact model = new CustomerContact()
                {
                    Name = contact.Name,
                    UserID = contact.UserID,
                    Department = contact.Department,
                    Title = contact.Title,
                    MobileNumber = contact.MobileNumber,
                    WorkNumber = contact.WorkNumber,
                    FaxNumber = contact.FaxNumber,
                    Skype = contact.Skype,
                    Email = contact.Email
                };
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    db.CustomerContacts.Add(model);
                    db.SaveChanges();
                }
            }
            return contact;
        }

        public void DeleteCustomerContact(int id)
        {
            CustomerContact model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.CustomerContacts.FirstOrDefault(x => x.CustomerContactID == id);
                model.DateDeleted = DateTime.Now;
                db.SaveChanges();
            }
        }
    }
}