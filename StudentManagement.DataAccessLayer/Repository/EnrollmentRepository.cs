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
    public class EnrollmentRepository : Repository<Enrollment>, IEnrollmentRepository
    {
        public ApplicationDbContext _dbContext;
        public EnrollmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Enrollment enrollment)
        {
            _dbContext.Update(enrollment);
        }
    }
}
