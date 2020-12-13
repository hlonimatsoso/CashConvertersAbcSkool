using AbcSkool.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AbcSkool.Interfaces
{
    public interface IStudentSubjectService : IGenericService<StudentSubjects>
    {
        Task<List<Subject>> GetAllSubjectsForStudentId(int Id);

        Task DeleteSubjectForStudent(int studentId, int subjectId);
    }
}
