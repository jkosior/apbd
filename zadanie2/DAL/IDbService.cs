using System.Collections.Generic;
using zadanie2.Dtos;
using zadanie2.Models;

namespace zadanie2.DAL
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();

        public IEnumerable<Student> GetStudent(string index);

        public int? GetStudiesIdByName(string name);

        public void CreateStudent(StudentCreateDto dto, int studiesId);

        public bool IsIndexNumberUnique(string indexNumber);

        public int? GetEnrollmentByStudyIdAndSemester(int studyId, int semester);

        public void PromoteStudents(int studiesId, int semester);
    }
}
