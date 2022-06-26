using StudentManagement.DataAccessLayer.Data;
using StudentManagement.DataAccessLayer.Repository.IRepository;
using StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DataAccessLayer.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public ApplicationDbContext _dbContext;
        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
            
        public void Update(Student student)
        {
            _dbContext.Students.Update(student);
        }
    }
}
