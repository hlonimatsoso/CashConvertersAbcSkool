using AbcSkool.Models;
using AbcSkool.UWP.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcSkool.UWP
{
    public static class AppData
    {
        public static SkoolClient Client = new SkoolClient();


        private static List<Subject> _subjects;

        public static List<Subject> Subjects
        {
            get
            {
                return _subjects;
            }
            set
            {
                _subjects = value;

                if (SubjectsUpdated != null)
                    SubjectsUpdated(Subjects);
            }
        }


        private static List<Student> _students;


        public static List<Student> Students
        {
            get
            {
                return _students;
            }
            set
            {
                _students = value;
                if (StudentsUpdated != null)
                    StudentsUpdated(Students);
            }
        }


        public static async Task RefreshSubjectAsync()
        {
            Subjects = await Client.GetAllSubjects();
        }

        //public static void RefreshStudents()
        //{
        //    Students = Client.GetAllStudents().Result;
        //}

        public static async Task RefreshStudentsAsync()
        {
            Students = await Client.GetAllStudents();
        }


        public static async Task RefreshDataAsync()
        {
            Subjects = await Client.GetAllSubjects();

            Students = await Client.GetAllStudents();
        }

        public static event Action<List<Subject>> SubjectsUpdated;

        public static event Action<List<Student>> StudentsUpdated;

        public static event Action<List<StudentSubjects>> StudentSubjectsUpdated;


    }
}
