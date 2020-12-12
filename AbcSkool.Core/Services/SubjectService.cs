using AbcSkool.Interfaces;
using AbcSkool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcSkool.Core.Services
{
    public class SubjectService : GenericAsyncService<Subject>, ISubjectService
    {
        public SubjectService(ISubjectRepository subjectRepo) : base(subjectRepo)
        {

        }

    }
}
