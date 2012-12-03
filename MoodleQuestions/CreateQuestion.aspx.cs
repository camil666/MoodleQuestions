using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoodleQuestions.Controls;
using QuestionsDAL;

namespace MoodleQuestions
{
    public partial class CreateQuestion : Page
    {
        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (PermissionHelper.UserIsSupervisor)
            //    ViewPlaceHolder.Controls.Add(LoadControl("~/Pages/CreateQuestion/SupervisorView.ascx"));
            //else 
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                ViewPlaceHolder.Controls.Add(LoadControl("~/Pages/CreateQuestion/LoggedUserView.ascx"));
            }
            else
            {
                ViewPlaceHolder.Controls.Add(LoadControl("~/Pages/CreateQuestion/AnonymousUserView.ascx"));
            }
        }

        #endregion
    }
}