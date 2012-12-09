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
using MoodleQuestions.Pages.CreateQuestion;
using QuestionsDAL;

namespace MoodleQuestions
{
    public partial class CreateQuestion : Page
    {
        #region Methods

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                ViewPlaceHolder.Controls.Add(new LoggedUserView());
            }
            else
            {
                ViewPlaceHolder.Controls.Add(new AnonymousUserView());
            }
        }

        #endregion
    }
}