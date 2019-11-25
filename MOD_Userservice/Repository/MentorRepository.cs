using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MOD.Userservice.Contextin;
using MOD.Userservice.Models;

namespace MOD.Userservice.Repository
{
    public class MentorRepository : IMentorRepository
    {
        private readonly UserServiceContext _context;
        public MentorRepository(UserServiceContext context)
        {
            _context = context;
        }

        public IList<Mentor> GetAll()
        {
            return _context.Mentors.ToList();
        }

        public void Mentor_Add(Mentor item)
        {
            _context.Mentors.Add(item);
            _context.SaveChanges();
        }

        
        public void Mentor_Delete(string id)
        {
            var item = _context.Mentors.Find(id);
            _context.Mentors.Remove(item);
            _context.SaveChanges();
        }

        public void Mentor_ResetPassword(Mentor item)
        {
            var obj = _context.Mentors.SingleOrDefault(i => i.Mentor_Email.Equals(i));
            obj.Mentor_Password = item.Mentor_Password;
            _context.SaveChanges();
        }

        public void Mentor_Update(Mentor item)
        {
            _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Mentor_ResetPassword(string email, string newpass)
        {
            var obj = _context.Mentors.SingleOrDefault(i => i.Mentor_Email == email);
            obj.Mentor_Password = newpass;
            _context.SaveChanges();
        }
    }
}
