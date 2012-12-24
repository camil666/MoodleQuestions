using System;

namespace MoodleQuestions.Pages.ManageQuestions
{
    public class StudentView : View<StudentPresenter>, IStudentView
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentView" /> class.
        /// </summary>
        public StudentView()
        {
            Presenter = new StudentPresenter(this);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Raises the <see cref="E:Load" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            Presenter.SetupGrid();
            base.OnLoad(e);
        }

        #endregion
    }
}