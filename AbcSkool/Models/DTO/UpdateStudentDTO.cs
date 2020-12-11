using System;
using System.Collections.Generic;
using System.Text;

namespace AbcSkool.Models.DTO
{
    public class UpdateStudentDTO
    {
        public int StudentId { get; set; }

        public int StudentNumber { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

    }
}
