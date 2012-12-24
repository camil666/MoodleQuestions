using System;

namespace MoodleQuestions.Pages.ManageQuestions
{
    public interface ISupervisorView : IView
    {
        #region Properties

        /// <summary>
        /// Gets or sets the user drop down data source.
        /// </summary>
        /// <value>
        /// The user drop down data source.
        /// </value>
        object UserDropDownDataSource { get; set; }

        /// <summary>
        /// Gets or sets the category drop down data source.
        /// </summary>
        /// <value>
        /// The category drop down data source.
        /// </value>
        object CategoryDropDownDataSource { get; set; }

        /// <summary>
        /// Gets the selected student id.
        /// </summary>
        /// <value>
        /// The selected student id.
        /// </value>
        Guid SelectedStudentId { get; }

        /// <summary>
        /// Gets the selected category id.
        /// </summary>
        /// <value>
        /// The selected category id.
        /// </value>
        int SelectedCategoryId { get; }

        /// <summary>
        /// Gets the name of the new category.
        /// </summary>
        /// <value>
        /// The name of the new category.
        /// </value>
        string NewCategoryName { get; }

        #endregion
    }
}
