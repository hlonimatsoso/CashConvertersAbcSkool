using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AbcSkool.Models
{
    public class StudentSubjects
    {
        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }


        public int SubjectId { get; set; }

        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }


    }
}
