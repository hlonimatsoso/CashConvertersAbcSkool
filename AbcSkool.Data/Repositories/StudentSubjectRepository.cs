using AbcSkool.Interfaces;
using AbcSkool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcSkool.Data.Repositories
{
    public class StudentSubjectRepository : GenericAsyncRepository<StudentSubjects>, IStudentSubjectRepository
    {
        public StudentSubjectRepository(AbcSkoolDbContext context) : base(context)
        { }

        public Task<List<Subject>> GetAllSubjectsForStudentId(int Id)
        {
            //var result = base._context.StudentSubjects.Join(base._context.StudentSubjects, S => S.StudentId, d => d, ss => ss.StudentId, (Student s, StudentSubjects ss)=> new { Subject = s});
            //throw new NotImplementedException();
            return null;
        }
    }
}
