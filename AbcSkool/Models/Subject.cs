using System;
using System.Collections.Generic;
using System.Text;

namespace AbcSkool.Models
{
    public class Subject
    {
        public string SubjectName { get; set; }

        public int SubjectId { get; set; }

        public string Description { get; set; }

        List<StudentSubjects> Students { get; set; }


    }
}
