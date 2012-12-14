using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuestionsDAL;

namespace MoodleQuestions.Controls
{
    public class QuestionViewer : WebControl
    {
        #region Fields

        private Question _question;

        #endregion

        #region Properties

        public Question Question
        {
            get { return _question; }
            set { _question = value; }
        }

        #endregion

        #region Constructors

        public QuestionViewer()
            : base(HtmlTextWriterTag.Div)
        {
        }

        #endregion

        #region Methods

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (_question != null)
            {
                Controls.Add(new LiteralControl(_question.Content));
                Controls.Add(new LiteralControl("<ol>"));

                for (int i = 1; i <= _question.QuestionAnswers.Count; ++i)
                {
                    Controls.Add(new LiteralControl("<li>"));
                    Controls.Add(new LiteralControl(_question.QuestionAnswers.ElementAt(i - 1).Content));
                    Controls.Add(new LiteralControl("</li>"));
                }

                Controls.Add(new LiteralControl("</ol>"));
            }
        }

        #endregion
    }
}