using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using zadanie2.Models;
using Microsoft.Extensions.Configuration;

namespace zadanie2.DAL
{
    public class DbService: IDbService
    {
        private readonly IConfiguration _config;

        public DbService(IConfiguration config)
        {
            _config = config;
        }

        public IEnumerable<Student> GetStudents()
        {
            using var client = new SqlConnection(_config["ConnectionString"]);
            client.Open();
            using var com = new SqlCommand(@"
SELECT
[s].[FirstName],
[s].[LastName],
[s].[BirthDate],
[s].[IndexNumber],
[e].[Semester],
[st].[Name] AS [StudyName]
FROM [Student] [s]
INNER JOIN [Enrollment] [e] ON [s].[IdEnrollment] = [e].[IdEnrollment]
INNER JOIN [Studies] [st] ON [st].[IdStudy] = [e].[IdStudy];
", client);

            var dr = com.ExecuteReader();

            while (dr.Read())
            {
                yield return new Student
                {
                    IndexNumber = dr["IndexNumber"].ToString(),
                    FirstName = dr["FirstName"].ToString(),
                    LastName = dr["LastName"].ToString(),
                    BirthDate = DateTime.Parse(dr["LastName"].ToString()),
                    Semester = dr["Semester"].ToString(),
                    StudyName = dr["StudyName"].ToString()
                };
            }

            client.Close();
        }

        public IEnumerable<Student> GetStudent(string index)
        {
            using var client = new SqlConnection(_config["ConnectionString"]);
            client.Open();
            using var com = new SqlCommand(@"
SELECT
[s].[FirstName],
[s].[LastName],
[s].[BirthDate],
[s].[IndexNumber],
[e].[Semester],
[st].[Name] AS [StudyName]
FROM [Student] [s]
INNER JOIN [Enrollment] [e] ON [s].[IdEnrollment] = [e].[IdEnrollment]
INNER JOIN [Studies] [st] ON [st].[IdStudy] = [e].[IdStudy]
WHERE [s].[IndexNumber] = @index
", client); 

            com.Parameters.Add(new SqlParameter("index", index));
            var dr = com.ExecuteReader();
            while(dr.Read())
            {
                yield return new Student
                {
                    IndexNumber = dr["IndexNumber"].ToString(),
                    FirstName = dr["FirstName"].ToString(),
                    LastName = dr["LastName"].ToString(),
                    BirthDate = DateTime.Parse(dr["LastName"].ToString()),
                    Semester = dr["Semester"].ToString(),
                    StudyName = dr["StudyName"].ToString()
                };
            }
            client.Close();
        }
    }
}
