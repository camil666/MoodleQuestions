using System;
using System.Web.UI;
using MoodleQuestions.Pages.ViewQuestions;

namespace MoodleQuestions
{
    public partial class ViewQuestions : Page
    {
        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            ViewPlaceHolder.Controls.Add(new View());
        }

        #endregion
    }
}