using System;
using System.Web;
using System.Web.UI.WebControls;

namespace MoodleQuestions.Pages.CreateQuestion
{
    public class LoggedUserView : BaseView
    {
        #region Fields

        private Button _saveButton;

        #endregion

        #region Constructors

        public LoggedUserView()
        {
            _saveButton = new Button()
            {
                Text = HttpContext.GetGlobalResourceObject("Strings", "SaveButtonText").ToString()
            };

            _saveButton.Click += SaveButton_Click;
        }

        #endregion

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Controls.Add(_saveButton);
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            Presenter.SaveQuestion();
        }

        #endregion
    }
}