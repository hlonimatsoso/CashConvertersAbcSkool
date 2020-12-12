using AbcSkool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcSkool.UWP.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            this.Subjects = new List<Subject>();
            this.Students = new List<Student>();
        }

        public List<Subject> Subjects { get; set; }

        private List<Student> _students;
        public List<Student> Students
        {
            get
            {
                return _students;
            }
            set
            {
                if (value != null)
                    _students = value;
                OnPropertyChanged("Students");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (!string.IsNullOrWhiteSpace(propertyName) && PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
