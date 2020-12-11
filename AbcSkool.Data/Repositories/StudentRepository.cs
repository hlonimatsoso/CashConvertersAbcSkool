using AbcSkool.Interfaces;
using AbcSkool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcSkool.Data.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(AbcSkoolDbContext context) : base(context)
        { }
    }
}
