﻿namespace SchoolProject.Data.AppMetaData
{
    public class Router
    {
        public const string root = "api";
        public const string version = "v1";
        public const string Rule = root + "/" + version + "/";
        //public const string Rule = "/" + version + "/";

        public static class StudentRouting
        {
            public const string Prefix = Rule + "Student/";
            public const string AllStudents = Prefix + "GetAllStudents";
            public const string Paginated = Prefix + "PaginatedList";
            public const string GetStudentDetails = Prefix + "StudentDetails/{Id}";
            public const string UpdateStudent = Prefix + "UpdateStudent";
            public const string CreateStudent = Prefix + "AddStudent";
            public const string DeleteStudent = Prefix + "DeleteStudent/{Id}";
        }

        public static class DepartmentRouting
        {
            public const string Prefix = Rule + "Department/";
            public const string AllDepartments = Prefix + "GetAllDepartments";
            public const string Paginated = Prefix + "PaginatedList";
            //public const string GetDepartmentDetails = Prefix + "DepartmentDetails/{Id}";
            public const string GetDepartmentDetails = Prefix + "DepartmentDetails/Id";
            public const string UpdateDepartment = Prefix + "UpdateDepartment";
            public const string CreateDepartment = Prefix + "AddDepartment";
            public const string DeleteDepartment = Prefix + "DeleteDepartment/{Id}";
        }

        public static class UserRouting
        {
            public const string Prefix = Rule + "Users/";
            public const string AllUsers = Prefix + "GetAllUsers";
            public const string Paginated = Prefix + "PaginatedList";
            public const string GetUserDetails = Prefix + "GetUserDetails/{Id}";
            public const string UpdateUser = Prefix + "UpdateUser";
            public const string CreateUser = Prefix + "AddUser";
            public const string DeleteUser = Prefix + "DeleteUser/{Id}";
        }


    }
}
