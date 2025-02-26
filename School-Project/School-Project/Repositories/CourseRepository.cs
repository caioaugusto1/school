﻿using System;
using System.Collections.Generic;
using System.Linq;
using School_Project.Context;
using School_Project.Entities;
using School_Project.Repositories.Interfaces;

namespace School_Project.Repositories
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(SchoolDBContext schoolDBContext) : base(schoolDBContext)
        {

        }

        public List<Course> GetAvaliable()
        {
            return (_schoolDBContext.Course.Where(c => c.EndDate >= DateTime.Now)).ToList();
        }

        public List<Course> GetNotAvaliable()
        {
            throw new System.NotImplementedException();
        }
    }
}