﻿using StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DataAccessLayer.Repository.IRepository
{
    public interface IStudentRepository:IRepository<Student>
    {
        void Update(Student student);

    }
}
