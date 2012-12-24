using System;
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

        /// <summary>
        /// Gets or sets the question.
        /// </summary>
        /// <value>
        /// The question.
        /// </value>
        public Question Question
        {
            get { return _question; }
            set { _question = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionViewer" /> class.
        /// </summary>
        public QuestionViewer()
            : base(HtmlTextWriterTag.Div)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.PreRender" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
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