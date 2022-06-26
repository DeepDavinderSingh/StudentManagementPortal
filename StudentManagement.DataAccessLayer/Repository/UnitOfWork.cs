using StudentManagement.DataAccessLayer.Data;
using StudentManagement.DataAccessLayer.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DataAccessLayer.Repository
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext; 
            Student=new StudentRepository(_dbContext);
            Course=new CourseRepository(_dbContext);
            Enrollment=new EnrollmentRepository(_dbContext);
        }
        public IStudentRepository Student { get; private set; }

        public ICourseRepository Course { get; private set; }

        public IEnrollmentRepository Enrollment { get; private set; }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
