using System;

namespace MoodleQuestions
{
    public class Student
    {
        #region Properties

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public Guid Id { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Student" /> class.
        /// </summary>
        /// <param name="fullName">The full name.</param>
        /// <param name="id">The id.</param>
        public Student(string fullName, Guid id)
        {
            Id = id;
            FullName = fullName;
        }

        #endregion
    }
}