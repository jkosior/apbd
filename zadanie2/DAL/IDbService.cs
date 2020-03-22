using System;
using System.Collections.Generic;
using zadanie2.Models;

namespace zadanie2.DAL
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();
    }
}
