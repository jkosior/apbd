using System.Collections.Generic;
using zadanie2.Dtos;
using zadanie2.Models;

namespace zadanie2.DAL
{
    public interface IDbService
    {
        public IEnumerable<StudentDto> GetStudents();

        public IEnumerable<StudentDto> GetStudent(string index);

        public int? GetStudiesIdByName(string name);

        public void CreateStudent(StudentDto dto, int studiesId);

        public bool IsIndexNumberUnique(string indexNumber);

        public int? GetEnrollmentByStudyIdAndSemester(int studyId, int semester);

        public void PromoteStudents(int studiesId, int semester);
    }
}
