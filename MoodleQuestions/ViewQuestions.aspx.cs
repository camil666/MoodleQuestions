using System;
using System.Web.UI;
using MoodleQuestions.Pages.ViewQuestions;

namespace MoodleQuestions
{
    public partial class ViewQuestions : Page
    {
        #region Methods

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            ViewPlaceHolder.Controls.Add(new View());
        }

        #endregion
    }
}