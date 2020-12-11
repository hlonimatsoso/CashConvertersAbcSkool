using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AbcSkool.Models.DTO
{
    public class AddStudentDTO
    {
        [Required]
        [Range(10000,99999,ErrorMessage ="Should be 5 numbers between 10 000 & 99 999")]
        public int StudentNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

    }
}
