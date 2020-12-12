﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AbcSkool.Models.DTO
{

    public class AddSubjectDTO
    {
        [Required]
        public string SubjectName { get; set; }

        [Required]
        public string Description { get; set; }

    }
   
}
