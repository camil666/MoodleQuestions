using System;
using System.Web.UI;
using MoodleQuestions.Pages.Reports;

namespace MoodleQuestions
{
    public partial class Raports : Page
    {
        #region Methods

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
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