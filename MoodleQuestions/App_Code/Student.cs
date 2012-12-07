using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodleQuestions
{
    public class Student
    {
        #region Properties

        public string FullName { get; set; }

        public Guid Id { get; set; }

        #endregion

        #region Constructors

        public Student(string fullName, Guid id)
        {
            Id = id;
            FullName = fullName;
        }

        #endregion
    }
}