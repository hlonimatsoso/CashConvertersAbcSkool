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
        public Task<List<Student>> GetAllStudents()
        {
            return Get<List<Student>>(Config.Api_AllStdents_Uri);
        }
    }
}
