﻿using AbcSkool.Models;
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

        public static List<Subject> Subjects { get; set; }

        public static List<Student> Students { get; set; }


        public static async Task RefreshSubjectAsync()
        {
            Subjects = await Client.GetAllSubjects();
        }

        public static void RefreshStudents()
        {
            Students = Client.GetAllStudents().Result;
        }

        public static async Task RefreshStudentsAsync()
        {
            Students = await Client.GetAllStudents();
        }


        public static async Task RefreshDataAsync()
        {
            //Subjects = await Client.GetAllSubjects();

            Students = await Client.GetAllStudents();
        }

  
    }
}