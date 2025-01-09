﻿using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.GenericRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.IRepositories
{
    public interface IStudentRepository : IGenericRepositoryAsync<Student>
    {
        public Task<List<Student>> GetAllStudentsAsync();
    }
}
