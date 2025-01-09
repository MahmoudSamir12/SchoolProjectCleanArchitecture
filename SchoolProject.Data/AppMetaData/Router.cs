namespace SchoolProject.Data.AppMetaData
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
            public const string AddStudent = Prefix + "AddStudent";
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
            public const string AddDepartment = Prefix + "AddDepartment";
            public const string DeleteDepartment = Prefix + "DeleteDepartment/{Id}";
        }


    }
}
