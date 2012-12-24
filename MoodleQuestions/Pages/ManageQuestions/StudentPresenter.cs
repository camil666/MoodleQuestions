using System;
using System.Web.Security;

namespace MoodleQuestions.Pages.ManageQuestions
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

        #region Methods

        /// <summary>
        /// Setups the grid.
        /// </summary>
        public void SetupGrid()
        {
            var user = Membership.GetUser();
            if (user != null)
            {
                var userId = Guid.Parse(user.ProviderUserKey.ToString());
                View.QuestionGridDataSource = Model.GetUserQuestions(userId);
            }
        }

        #endregion
    }
}