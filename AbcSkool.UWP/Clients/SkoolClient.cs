using AbcSkool.Interfaces;
using AbcSkool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcSkool.UWP.Clients
{
    public class SkoolClient : RestClient, ISkoolClient
    {
        public async Task<List<Student>> GetAllStudents()
        {
            //if (AppData.Students == null)
            AppData.Students = await Get<List<Student>>(Config.REST_Endpoints_Students);

            return AppData.Students;
        }

        public async Task<List<Subject>> GetAllSubjects()
        {
            //if (AppData.Subjects == null)
            AppData.Subjects = await Get<List<Subject>>(Config.REST_Endpoints_Subjects);

            return AppData.Subjects;
        }
    }
}
