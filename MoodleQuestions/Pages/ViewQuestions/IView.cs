using System;
using System.Collections.Generic;

namespace MoodleQuestions.Pages.ViewQuestions
{
    public interface IView
    {
        #region Properties

        /// <summary>
        /// Gets or sets the question repeater data source.
        /// </summary>
        /// <value>
        /// The question repeater data source.
        /// </value>
        object QuestionRepeaterDataSource { get; set; }

        /// <summary>
        /// Gets or sets the category data source.
        /// </summary>
        /// <value>
        /// The category data source.
        /// </value>
        object CategoryDataSource { get; set; }

        /// <summary>
        /// Gets the selected category id.
        /// </summary>
        /// <value>
        /// The selected category id.
        /// </value>
        int SelectedCategoryId { get; }

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

        #endregion

        #region Methods

        /// <summary>
        /// Gets the question ids.
        /// </summary>
        /// <returns>Ids of questions.</returns>
        IEnumerable<int> GetQuestionIds();

        #endregion
    }
}
