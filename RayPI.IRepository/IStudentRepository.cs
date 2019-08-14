﻿using RayPI.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RayPI.IRepository
{
    public interface IStudentRepository:IBaseRepository<Student>
    {
        Student GetByName(string name);
    }
}
