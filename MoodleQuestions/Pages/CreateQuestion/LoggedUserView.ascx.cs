using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuestionsDAL;

namespace MoodleQuestions.Pages.CreateQuestion
{
    public partial class LoggedUserView : UserControl, IView
    {
        #region Fields

        private LoggedUserPresenter _presenter;

        #endregion

        #region Constructors

        public LoggedUserView()
        {
            _presenter = new LoggedUserPresenter(this);
        }

        #endregion

        #region IView Methods

        public Question GetQuestion()
        {
            return AnonymousUserView.GetQuestion();
        }

        #endregion

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveQuestionButton_Click(object sender, EventArgs e)
        {
            _presenter.SaveQuestion();
        }

        #endregion
    }
}