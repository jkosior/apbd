﻿using System;
using System.Collections.Generic;
using zadanie2.Models;

namespace zadanie2.DAL
{
    public class MockDbService: IDbService
    {
        private static IEnumerable<Student> _students;
        static MockDbService()
        {
            _students = new List<Student>
            {
                new Student{StudentId=1, FirstName="Jan", LastName="Kowalski"},
                new Student{StudentId=2, FirstName="Anna", LastName="Malewska"},
                new Student{StudentId=3, FirstName="Andrzej", LastName="Andrzejewicz"},
            };
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }
    }
}