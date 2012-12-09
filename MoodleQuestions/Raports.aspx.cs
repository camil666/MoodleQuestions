using System;
using System.Web.UI;
using MoodleQuestions.Pages.Raports;

namespace MoodleQuestions
{
    public partial class Raports : Page
    {
        #region Methods

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            ViewPlaceHolder.Controls.Add(new View());
        }

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    ViewPlaceHolder.Controls.Add(new View());
        //}

        #endregion
    }
}