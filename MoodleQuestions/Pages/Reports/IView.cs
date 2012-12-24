using System;

namespace MoodleQuestions.Pages.Reports
{
    public interface IView
    {
        #region Properties

        /// <summary>
        /// Gets the selected student id.
        /// </summary>
        /// <value>
        /// The selected student id.
        /// </value>
        Guid SelectedStudentId { get; }

        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        DateTime? StartDate { get; }

        /// <summary>
        /// Gets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        DateTime? EndDate { get; }

        /// <summary>
        /// Sets the question count.
        /// </summary>
        /// <value>
        /// The question count.
        /// </value>
        string QuestionCount { set; }

        /// <summary>
        /// Sets the rated question count.
        /// </summary>
        /// <value>
        /// The rated question count.
        /// </value>
        string RatedQuestionCount { set; }

        /// <summary>
        /// Sets the unrated question count.
        /// </summary>
        /// <value>
        /// The unrated question count.
        /// </value>
        string UnratedQuestionCount { set; }

        /// <summary>
        /// Sets the average rating.
        /// </summary>
        /// <value>
        /// The average rating.
        /// </value>
        string AverageRating { set; }

        #endregion
    }
}
