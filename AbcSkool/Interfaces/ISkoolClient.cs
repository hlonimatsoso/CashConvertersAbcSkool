using AbcSkool.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AbcSkool.Interfaces
{
    public interface ISkoolClient
    {
        Task<List<Student>> GetAllStudents();
        Task<List<Subject>> GetAllSubjects();

    }
}
