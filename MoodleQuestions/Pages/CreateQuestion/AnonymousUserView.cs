using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoodleQuestions.Controls;
using QuestionsDAL;

namespace MoodleQuestions.Pages.CreateQuestion
{
    public class AnonymousUserView : BaseView, IView
    {
        #region Constructors

        public AnonymousUserView()
        {
            QuestionComposerControl.AnonymousMode = true;
        }

        #endregion
    }
}