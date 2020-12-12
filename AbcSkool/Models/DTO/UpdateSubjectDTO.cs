using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AbcSkool.Models.DTO
{

    public class UpdateSubjectDTO
    {

        [Required]
        public int SubjectId { get; set; }


        [Required]
        public string SubjectName { get; set; }

        [Required]
        public string Description { get; set; }

    }
   
}
