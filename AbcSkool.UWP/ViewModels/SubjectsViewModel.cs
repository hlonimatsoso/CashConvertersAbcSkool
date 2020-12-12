using AbcSkool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcSkool.UWP.ViewModels
{
    class SubjectsViewModel : Notifiable
    {
        public SubjectsViewModel()
        {
            this.Subjects = new List<Subject>();
        }


        private List<Subject> _subjects;
        public List<Subject> Subjects
        {
            get
            {
                if (_subjects == null)
                    _subjects = new List<Subject>();
                return _subjects;
            }
            set
            {
                if (value != null)
                    _subjects = value;
                PropertyHasChanged("Subjects");
            }
        }



        private string _subjectName;
        public string SubjectName
        {
            get { return _subjectName; }
            set
            {
                _subjectName = value;
                PropertyHasChanged("SubjectName");
                CheckCanSubmit();
            }
        }


        public bool IsSubjectNameEmpty
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.SubjectName);
            }
        }

       

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                PropertyHasChanged("Description");
                CheckCanSubmit();

            }
        }


        public bool IsDescriptionEmpty
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.Description);
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

        private void CheckCanSubmit()
        {
            if (!IsSubjectNameEmpty && !IsDescriptionEmpty)
                this.CanSubmit = true;
            else
                this.CanSubmit = false;

        }

    }
}
