using System.Collections.Generic;

namespace MoodleQuestions.Pages.ManageQuestions
{
    public interface IView
    {
        #region Properties

        /// <summary>
        /// Gets or sets the question grid data source.
        /// </summary>
        /// <value>
        /// The question grid data source.
        /// </value>
        object QuestionGridDataSource { get; set; }

        /// <summary>
        /// Gets the question ids.
        /// </summary>
        /// <value>
        /// The question ids.
        /// </value>
        IEnumerable<int> QuestionIds { get; }

        #endregion
    }
}
