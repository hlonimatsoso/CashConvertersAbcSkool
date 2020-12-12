using AbcSkool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcSkool.UWP.ViewModels
{
    class StudentsViewModel : Notifiable
    {
        public StudentsViewModel()
        {
            this.Students = new List<Student>();
        }


        private List<Student> _students;
        public List<Student> Students
        {
            get
            {
                if (_students == null)
                    _students = new List<Student>();
                return _students;
            }
            set
            {
                if (value != null)
                    _students = value;
                PropertyHasChanged("Students");
            }
        }


        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                //if (string.IsNullOrWhiteSpace(value))
                //    return;

                _name = value;
                PropertyHasChanged("Name");
                CheckCanSubmit();
            }
        }

        public bool IsNameEmpty
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.Name);
            }
        }

        private void CheckCanSubmit()
        {
            if (!IsNameEmpty && !string.IsNullOrWhiteSpace(Surname))
                this.CanSubmit = true;
            else
                this.CanSubmit = false;

        }

        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set
            {
                //if (string.IsNullOrWhiteSpace(value))
                //    return;

                _surname = value;
                PropertyHasChanged("Surname");
                CheckCanSubmit();

            }
        }

        public bool IsSurNameEmpty
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.Surname);
            }
        }


        private bool _canSubmit;
        public bool CanSubmit
        {
            get { return _canSubmit; }
            set
            {
                _canSubmit = value;
                PropertyHasChanged("CanSubmit");
            }
        }
    }
}
