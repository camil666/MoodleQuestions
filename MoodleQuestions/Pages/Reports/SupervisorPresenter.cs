namespace MoodleQuestions.Pages.Reports
{
    public class SupervisorPresenter : Presenter<ISupervisorView, Model>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SupervisorPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public SupervisorPresenter(ISupervisorView view)
            : base(view)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets up the drop down.
        /// </summary>
        public void SetupDropDown()
        {
            View.DropDownDataSource = PermissionHelper.GetStudents();
        }

        #endregion
    }
}