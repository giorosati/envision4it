using Envision;
using Envision.Adapters.Interfaces;
using Envision.data;
using Envision.Data.Model;
using Envision.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Envision.Adapters.Adapters
{
    public class UserDetailsAdapter : IUserDetailsAdapter
    {
        public List<ApplicationUserVM> GetUsers()
        {
            List<ApplicationUserVM> model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Users.OrderBy(x => x.Company).Select(x => new ApplicationUserVM()
                {
                    Name = x.Name,
                    Company = x.Company,
                    Address1 = x.Address1,
                    Address2 = x.Address2,
                    City = x.City,
                    State = x.State,
                    Zip = x.Zip,
                    Phone = x.Phone,
                    Fax = x.Fax,
                    Email = x.Email,
                    UserName = x.UserName,
                    Id = x.Id,

                    CustomerNotes = x.CustomerNotes.Where(cn => cn.DateDeleted == null).Select(cn => new CustomerNoteVM()
                    {
                        CustomerNoteID = cn.CustomerNoteID,
                        DateEntered = cn.DateEntered,
                        Note = cn.Note,
                        UserID = cn.UserID
                    }).ToList(),
                }).ToList();
            }

            return model;
        }

        // public ApplicationUserVM GetUser(int id)

        //needs other methods: add, edit, delete
    }
}