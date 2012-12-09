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

        private Label _questionContentLabel;
        private Question _question;
        private Collection<Label> _answersContentLabels;

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
            _answersContentLabels = new Collection<Label>();
            _questionContentLabel = new Label();
        }

        #endregion

        #region Methods

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (_question != null)
            {
                _questionContentLabel.Text = _question.Content;
                Controls.Add(_questionContentLabel);

                for (int i = 1; i <= _question.QuestionAnswers.Count; ++i)
                {
                    var answerContentLabel = new Label() { Text = string.Format("{0}. {1}", i, _question.QuestionAnswers.ElementAt(i - 1).Content) };
                    _answersContentLabels.Add(answerContentLabel);
                    Controls.Add(answerContentLabel);
                }
            }
        }

        #endregion
    }
}