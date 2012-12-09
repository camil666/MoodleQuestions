using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoodleQuestions.Pages.ManageQuestions;
using QuestionsDAL;

namespace MoodleQuestions
{
    public partial class ManageQuestions : Page
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