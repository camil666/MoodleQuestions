using System;
using System.Collections.Generic;
using MoodleQuestions.Repositories;
using QuestionsDAL;

namespace MoodleQuestions.Pages.Reports
{
    public class Model
    {
        #region Methods

        /// <summary>
        /// Gets the student questions.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>Student questions.</returns>
        public IEnumerable<Question> GetStudentQuestions(Guid studentId, DateTime? startDate, DateTime? endDate)
        {
            return QuestionRepository.Find(item => item.AuthorId == studentId && item.CreationDate >= startDate && item.CreationDate <= endDate && item.IsDeleted == false);
        }

        /// <summary>
        /// Gets all questions.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>All the questions.</returns>
        public IEnumerable<Question> GetAllQuestions(DateTime? startDate, DateTime? endDate)
        {
            return QuestionRepository.Find(item => item.CreationDate >= startDate && item.CreationDate <= endDate && item.IsDeleted == false);
        }

        #endregion
    }
}