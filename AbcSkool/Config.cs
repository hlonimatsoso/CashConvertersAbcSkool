using System;
using System.Collections.Generic;
using System.Text;

namespace AbcSkool
{
    public static class Config
    {
        public static string ApiBaseUrl = "http://localhost:5000/api/";
        
        public static string REST_Endpoints_Students = "students";
        public static string REST_Endpoints_Subjects = "subjects";

        public static int StudentNumber_MinValue = 10000;
        public static int StudentNumber_MaxValue = 99999;

        public static string ButtonAction_Add = "Add";
        public static string ButtonAction_Update = "Update";


    }
}
