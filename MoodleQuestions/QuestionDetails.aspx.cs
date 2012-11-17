using System;
using System.Web.UI;

namespace MoodleQuestions
{
    public partial class QuestionDetails : Page
    {
        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (PermissionHelper.UserIsSupervisor)
                ViewPlaceHolder.Controls.Add(LoadControl("~/Pages/QuestionDetails/SupervisorView.ascx"));
            else if (PermissionHelper.UserIsStudent)
                ViewPlaceHolder.Controls.Add(LoadControl("~/Pages/QuestionDetails/StudentView.ascx"));
        }

        #endregion
    }
}