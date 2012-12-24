namespace MoodleQuestions.Pages.Reports
{
    public class StudentPresenter : Presenter<IStudentView, Model>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public StudentPresenter(IStudentView view)
            : base(view)
        {
        }

        #endregion
    }
}