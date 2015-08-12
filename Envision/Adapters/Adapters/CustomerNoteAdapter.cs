using Envision.Adapters.Interfaces;
using Envision.data;
using Envision.Data.Model;
using Envision.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Envision.Adapters.Adapters
{
    public class CustomerNoteAdapter : ICustomerNoteAdapter
    {
        public List<CustomerNoteVM> GetCustomerNotes(string id)
        {
            List<CustomerNoteVM> model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.CustomerNotes.Where(x => x.DateDeleted == null && x.UserID == id).OrderBy(x => x.DateEntered).Take(20).Select(x => new CustomerNoteVM()
                {
                    CustomerNoteID = x.CustomerNoteID,
                    DateEntered = x.DateEntered,
                    Note = x.Note,
                    UserID = x.UserID
                }).ToList();
            }
            return model;
        }

        public CustomerNoteVM GetCustomerNote(int id)
        {
            CustomerNoteVM model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.CustomerNotes.Where(x => x.CustomerNoteID == id).Select(x => new CustomerNoteVM()
                   {
                       CustomerNoteID = x.CustomerNoteID,
                       DateEntered = x.DateEntered,
                       Note = x.Note,
                       UserID = x.UserID
                   }).FirstOrDefault();
            }
            return model;
        }

        public CustomerNoteVM GetEditCustomerNote(int id)
        {
            CustomerNoteVM customerNote;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                customerNote = db.CustomerNotes.Where(x => x.CustomerNoteID == id).Select(x => new CustomerNoteVM()
                {
                    CustomerNoteID = x.CustomerNoteID,
                    DateEntered = x.DateEntered,
                    Note = x.Note,
                    UserID = x.UserID
                }).FirstOrDefault();
            };
            return customerNote;
        }

        public void EditCustomerNote(CustomerNoteVM customerNote, int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                CustomerNote model;
                model = db.CustomerNotes.FirstOrDefault(x => x.CustomerNoteID == id);
                model.DateEntered = customerNote.DateEntered.Value;
                model.Note = customerNote.Note;
                model.UserID = customerNote.UserID;
                db.SaveChanges();
            };
        }

        public CustomerNoteVM AddCustomerNote(string id, CustomerNoteVM customerNote)
        {
            CustomerNote newNote = new CustomerNote()
            {
                DateEntered = DateTime.Now,
                Note = customerNote.Note,
                UserID = id
            };
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.CustomerNotes.Add(newNote);
                db.SaveChanges();
            }
            return customerNote;
        }

        public void DeleteCustomerNote(int id)
        {
            CustomerNote model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.CustomerNotes.FirstOrDefault(x => x.CustomerNoteID == id);
                model.DateDeleted = DateTime.Now;
                db.SaveChanges();
            }
        }
    }
}