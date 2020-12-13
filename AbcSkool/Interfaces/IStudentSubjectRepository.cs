using AbcSkool.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AbcSkool.Interfaces
{
    public interface IStudentSubjectRepository : IGenericRepository<StudentSubjects>
    {
        Task<List<Subject>> GetAllSubjectsForStudentId(int Id);

    }
}
