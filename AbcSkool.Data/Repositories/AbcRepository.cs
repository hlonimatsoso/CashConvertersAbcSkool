using AbcSkool.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcSkool.Data.Repositories
{
    public class AbcRepository : IAbcRepository
    {
        public IStudentRepository StudentRepository { get ; set ; }

        public AbcRepository(IStudentRepository studentRepo)
        {
            this.StudentRepository = studentRepo;
        }
    
    }
}
