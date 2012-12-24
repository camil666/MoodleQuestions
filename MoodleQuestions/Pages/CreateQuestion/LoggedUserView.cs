using System;
using System.Web;
using System.Web.UI.WebControls;

namespace MoodleQuestions.Pages.CreateQuestion
{
    public class LoggedUserView : View
    {
        #region Fields

        private Button _saveButton;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggedUserView" /> class.
        /// </summary>
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

        /// <summary>
        /// Raises the <see cref="E:Init" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Controls.Add(_saveButton);
        }

        /// <summary>
        /// Handles the Click event of the SaveButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            Presenter.SaveQuestion();
        }

        #endregion
    }
}