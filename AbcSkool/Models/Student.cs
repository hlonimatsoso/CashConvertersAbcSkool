﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AbcSkool.Models
{
    [Table("Students")]
    public class Student
    {
        public int StudentId { get; set; }

        public int StudentNumber { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        List<StudentSubjects> Subjects { get; set; }

    }
}