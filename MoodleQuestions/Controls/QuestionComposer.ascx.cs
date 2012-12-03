using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuestionsDAL;

namespace MoodleQuestions.Controls
{
    public partial class QuestionComposer : UserControl
    {
        #region Fields

        //private Question _question;
        private Collection<QuestionAnswerControl> _answerControls;

        #endregion

        #region Properties

        public int AnswerCount { get; set; }

        public string AnswerLabelText { get; set; }

        public string FractionLabelText { get; set; }

        public string ValidationErrorMessage { get; set; }

        public Question Question
        {
            get
            {
                var question = new Question()
                {
                    CreationDate = DateTime.Now,
                    Content = QuestionContentTextBox.Text
                };

                var user = Membership.GetUser();
                if (user != null)
                    question.AuthorId = Guid.Parse(user.ProviderUserKey.ToString());

                foreach (var control in _answerControls)
                {
                    question.QuestionAnswers.Add(
                        new QuestionAnswer()
                        {
                            Content = control.AnswerContent,
                            Fraction = DoubleHelper.Parse(control.FractionValue)
                        });
                }

                return question;
            }

            set
            {
                //_question = value;
                QuestionContentTextBox.Text = value.Content;
                foreach (var control in _answerControls)
                {
                    control.AnswerContent = value.QuestionAnswers.ElementAt(_answerControls.IndexOf(control)).Content;
                    control.FractionValue = value.QuestionAnswers.ElementAt(_answerControls.IndexOf(control)).Fraction.ToString() + "%";
                }
            }
        }

        #endregion

        #region Constructors

        public QuestionComposer()
        {
            _answerControls = new Collection<QuestionAnswerControl>();
        }

        #endregion

        #region Methods

        public Question GetQuestion()
        {
            var question = new Question()
            {
                CreationDate = DateTime.Now,
                Content = QuestionContentTextBox.Text
            };

            var user = Membership.GetUser();
            if (user != null)
                question.AuthorId = Guid.Parse(user.ProviderUserKey.ToString());

            foreach (var control in _answerControls)
            {
                question.QuestionAnswers.Add(
                    new QuestionAnswer()
                    {
                        Content = control.AnswerContent,
                        Fraction = DoubleHelper.Parse(control.FractionValue)
                    });
            }

            return question;
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (!Page.IsPostBack)
            {
                var itemCollection = new Collection<ListItem>();
                for (int fractionValue = -100; fractionValue <= 100; fractionValue += 5)
                {
                    itemCollection.Add(new ListItem(fractionValue.ToString()));
                }

                itemCollection.Add(new ListItem("11,111"));
                itemCollection.Add(new ListItem("12,5"));
                itemCollection.Add(new ListItem("14,2857"));
                itemCollection.Add(new ListItem("16,666"));
                itemCollection.Add(new ListItem("33,333"));
                itemCollection.Add(new ListItem("66,666"));
                itemCollection.Add(new ListItem("83,333"));
                itemCollection.Add(new ListItem("-11,111"));
                itemCollection.Add(new ListItem("-12,5"));
                itemCollection.Add(new ListItem("-14,2857"));
                itemCollection.Add(new ListItem("-16,666"));
                itemCollection.Add(new ListItem("-33,333"));
                itemCollection.Add(new ListItem("-66,666"));
                itemCollection.Add(new ListItem("-83,333"));

                foreach (var control in _answerControls)
                {
                    control.FractionDropDownDataSource = itemCollection.OrderByDescending(item => DoubleHelper.Parse(item.Text));
                    control.DataBind();
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (_question != null)
            //{
            //    QuestionContentTextBox.Text = _question.Content;
            //    foreach (var control in _answerControls)
            //    {
            //        control.AnswerContent = _question.QuestionAnswers.ElementAt(_answerControls.IndexOf(control)).Content;
            //        control.FractionValue = _question.QuestionAnswers.ElementAt(_answerControls.IndexOf(control)).Fraction.ToString() + "%";
            //    }
            //}

            for (int i = 0; i < AnswerCount; ++i)
            {
                var control = new QuestionAnswerControl()
                    {
                        AnswerLabelText = string.Format(AnswerLabelText, i + 1),
                        FractionLabelText = FractionLabelText,
                        ValidationErrorMessage = ValidationErrorMessage
                    };

                _answerControls.Add(control);
                AnswersPlaceHolder.Controls.Add(control);
            }
        }

        #endregion
    }
}