using AbcSkool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcSkool.UWP.ViewModels
{
    class MainPageViewModel
    {
        public MainPageViewModel()
        {
            this.Subjects = new List<Subject>();
            this.Students = new List<Student>();
        }

        public List<Subject> Subjects { get; set; }

        public List<Student> Students { get; set; }
    }
}
