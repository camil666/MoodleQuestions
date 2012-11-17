using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MoodleQuestions
{
    public static class PermissionHelper
    {
        #region Constants

        private const string Supervisor = "Supervisor";
        private const string Student = "Student";

        #endregion

        #region Properties

        public static bool UserIsSupervisor
        {
            get { return IsUserInRole(Supervisor); }
        }

        public static bool UserIsStudent
        {
            get { return IsUserInRole(Student); }
        }

        #endregion

        #region Methods

        public static string[] GetStudents()
        {
            return Roles.GetUsersInRole(Student);
        }

        private static bool IsUserInRole(string roleName)
        {
            var rolesArray = Roles.GetRolesForUser();
            return rolesArray.Contains(roleName);
        }

        #endregion
    }
}