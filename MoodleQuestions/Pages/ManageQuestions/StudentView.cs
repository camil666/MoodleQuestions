using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoodleQuestions.Pages.ManageQuestions
{
    public class StudentView : View<StudentPresenter>, IStudentView
    {
        #region Constructors

        public StudentView()
        {
            Presenter = new StudentPresenter(this);
        }

        #endregion

        #region Methods

        protected override void OnLoad(EventArgs e)
        {
            Presenter.SetupGrid();
            base.OnLoad(e);
        }

        #endregion
    }
}