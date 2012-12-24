namespace MoodleQuestions.Pages.Reports
{
    public interface ISupervisorView : IView
    {
        #region Properties

        /// <summary>
        /// Gets or sets the drop down data source.
        /// </summary>
        /// <value>
        /// The drop down data source.
        /// </value>
        object DropDownDataSource { get; set; }

        #endregion
    }
}
