using StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DataAccessLayer.Repository.IRepository
{
    public interface IEnrollmentRepository:IRepository<Enrollment>
    {
        void Update(Enrollment enrollment);
    }
}
