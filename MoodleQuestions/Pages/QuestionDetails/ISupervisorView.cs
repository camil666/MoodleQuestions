namespace MoodleQuestions.Pages.QuestionDetails
{
    public interface ISupervisorView : IView
    {
        #region Properties

        /// <summary>
        /// Gets the name of the question.
        /// </summary>
        /// <value>
        /// The name of the question.
        /// </value>
        string QuestionName { get; }

        /// <summary>
        /// Gets the question category id.
        /// </summary>
        /// <value>
        /// The question category id.
        /// </value>
        int? QuestionCategoryId { get; }

        /// <summary>
        /// Gets or sets the question category data source.
        /// </summary>
        /// <value>
        /// The question category data source.
        /// </value>
        object QuestionCategoryDataSource { get; set; }

        /// <summary>
        /// Gets the selected rating.
        /// </summary>
        /// <value>
        /// The selected rating.
        /// </value>
        int? SelectedRating { get; }

        #endregion
    }
}
