using System.Collections.Generic;
using System.Linq;
using QuestionsDAL;

namespace MoodleQuestions
{
    public static class PermissionHelper
    {
        #region Constants

        private const string Supervisor = "Supervisor";
        private const string Student = "Student";

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether user is supervisor.
        /// </summary>
        /// <value>
        ///   <c>true</c> if user is supervisor; otherwise, <c>false</c>.
        /// </value>
        public static bool UserIsSupervisor
        {
            get { return IsUserInRole(Supervisor); }
        }

        /// <summary>
        /// Gets a value indicating whether user is student.
        /// </summary>
        /// <value>
        ///   <c>true</c> if user is student; otherwise, <c>false</c>.
        /// </value>
        public static bool UserIsStudent
        {
            get { return IsUserInRole(Student); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the students.
        /// </summary>
        /// <returns>List of students.</returns>
        public static IEnumerable<Student> GetStudents()
        {
            var students = new List<Student>();
            var studentAccountNames = System.Web.Security.Roles.GetUsersInRole(Student);

            using (var context = new Entities())
            {
                foreach (var accountname in studentAccountNames)
                {
                    var foundStudent = (from item in context.Users
                                        where item.UserName == accountname
                                        select item).FirstOrDefault();

                    students.Add(new Student(string.Format("{0} {1}", foundStudent.FirstName, foundStudent.LastName), foundStudent.UserId));
                }
            }

            return students;
        }

        private static bool IsUserInRole(string roleName)
        {
            var rolesArray = System.Web.Security.Roles.GetRolesForUser();
            return rolesArray.Contains(roleName);
        }

        #endregion
    }
}