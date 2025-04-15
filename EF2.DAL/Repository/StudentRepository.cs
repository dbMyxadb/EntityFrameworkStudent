using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.DAL.Entities;

namespace EF.DAL
{
    public class StudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository()
        {
            _context = new AppDbContext();
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students;
        }

        public void Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();

        }
        public void Add(List<Student> student)
        {
            _context.Students.AddRange(student);
            _context.SaveChanges();

        }


        public void Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }
        public void Update(List<Student> student)
        {
            _context.Students.UpdateRange(student);
            _context.SaveChanges();
        }


        public void Delete(Student student)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
        public void Delete(List<Student> student)
        {
            _context.Students.RemoveRange(student);
            _context.SaveChanges();
        }
    }
}
