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
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public ApplicationDbContext _dbContext;
        public CourseRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Course course)
        {
            _dbContext.Courses.Update(course);
        }
    }
}
