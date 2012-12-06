using System;
using System.Web.UI;
using MoodleQuestions.Pages.QuestionDetails;

namespace MoodleQuestions
{
    public partial class QuestionDetails : Page
    {
        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (PermissionHelper.UserIsSupervisor)
            {
                ViewPlaceHolder.Controls.Add(new SupervisorView());
            }
            else if (PermissionHelper.UserIsStudent)
            {
                ViewPlaceHolder.Controls.Add(new StudentView());
            }
        }

        #endregion
    }
}