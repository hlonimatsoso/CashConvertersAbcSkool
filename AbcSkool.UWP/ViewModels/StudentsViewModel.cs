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
            AppData.StudentsUpdated += AppData_StudentsUpdated;

        }

        private void AppData_StudentsUpdated(List<Student> obj)
        {
            this.Students = obj;

        }


        private int _studentId;
        public int StudentId
        {
            get { return _studentId; }
            set
            {
                _studentId = value;
                PropertyHasChanged("StudentId");

            }
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


        private int _studentNumber;
        public int StudentNumber
        {
            get { return _studentNumber; }
            set
            {
                _studentNumber = value;
                PropertyHasChanged("StudentNumber");

            }
        }


        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
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
            if (IsItemSelected)
                this.CanSubmit = true;
            else if (!IsNameEmpty && !IsSurNameEmpty && !IsItemSelected)
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


        private string _submitButtonText;
        public string SubmitButtonText
        {
            get
            {
                if (IsItemSelected)
                    SubmitButtonText = $"{Config.ButtonAction_Update} {Name}";
                else
                    SubmitButtonText = $"{Config.ButtonAction_Add} Student";

                return _submitButtonText;
            }
            set
            {
                _submitButtonText = value;
                PropertyHasChanged("SubmitButtonText");

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


        private bool _isItemSelected;
        public bool IsItemSelected
        {
            get { return _isItemSelected; }
            set
            {
                _isItemSelected = value;

                PropertyHasChanged("IsItemSelected");
                PropertyHasChanged("SubmitButtonText");

            }
        }
    }
}
