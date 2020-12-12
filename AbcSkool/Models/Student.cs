using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AbcSkool.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public int StudentNumber { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        List<StudentSubjects> Subjects { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Student ID: {StudentId},");
            sb.Append($"Student Name: {Name},");
            sb.Append($"Student Surname: {Surname}");

            return sb.ToString(); 
        }

    }
}
