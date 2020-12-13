using AbcSkool.Interfaces;
using AbcSkool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcSkool.Core.Services
{
    public class StudentSubjectService : GenericAsyncService<StudentSubjects>, IStudentSubjectService
    {
        public StudentSubjectService(IStudentSubjectRepository studentSubjectRepo) : base(studentSubjectRepo)
        {

        }

        public Task DeleteSubjectForStudent(int studentId, int subjectId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Subject>> GetAllSubjectsForStudentId(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
