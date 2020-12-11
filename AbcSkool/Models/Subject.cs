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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Subject ID: {SubjectId},");
            sb.Append($"Subject Name: {SubjectName},");
            sb.Append($"Description: '{Description}'");

            return sb.ToString();
        }
    }
}
