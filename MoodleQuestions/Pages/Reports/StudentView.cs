using System;
using System.Web.Security;

namespace MoodleQuestions.Pages.Reports
{
    public class StudentView : View<StudentPresenter>, IStudentView
    {
        #region Construtors

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentView" /> class.
        /// </summary>
        public StudentView()
        {
            Presenter = new StudentPresenter(this);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the selected student id.
        /// </summary>
        /// <value>
        /// The selected student id.
        /// </value>
        public override Guid SelectedStudentId
        {
            get
            {
                return Guid.Parse(Membership.GetUser().ProviderUserKey.ToString());
            }
        }

        #endregion
    }
}