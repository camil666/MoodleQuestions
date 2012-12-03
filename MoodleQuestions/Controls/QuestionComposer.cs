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
    public class QuestionComposer : WebControl
    {
        #region Fields

        private Collection<QuestionAnswerControl> _answerControls;
        private TextBox _questionContentTextBox;
        private DropDownList _questionCountDropDown;
        private Label _questionLabel;
        private CustomValidator _validator;

        #endregion

        #region Properties

        public int AnswerCount { get; set; }

        public string QuestionLabelText
        {
            get { return _questionLabel.Text; }
            set { _questionLabel.Text = value; }
        }

        public string AnswerLabelText { get; set; }

        public string FractionLabelText { get; set; }

        public string ValidatorErrorMessage
        {
            get { return _validator.ErrorMessage; }
            set { _validator.ErrorMessage = value; }
        }

        public Question Question
        {
            get
            {
                var question = new Question()
                {
                    CreationDate = DateTime.Now,
                    Content = _questionContentTextBox.Text
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
                _questionContentTextBox.Text = value.Content;
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
            : base(HtmlTextWriterTag.Div)
        {
            _answerControls = new Collection<QuestionAnswerControl>();
            _questionContentTextBox = new TextBox() { TextMode = TextBoxMode.MultiLine };
            _questionLabel = new Label();
            _validator = new CustomValidator()
            {
                Display = ValidatorDisplay.Dynamic,
                ClientValidationFunction = "Answers.ValidateSum"
            };
        }

        #endregion

        #region Methods

        public Question GetQuestion()
        {
            var question = new Question()
            {
                CreationDate = DateTime.Now,
                Content = _questionContentTextBox.Text
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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Page.ClientScript.RegisterClientScriptInclude("TinyMce", ResolveClientUrl("~/Scripts/tiny_mce/tiny_mce.js"));
            Page.ClientScript.RegisterClientScriptInclude("ComposerScripts", ResolveClientUrl("~/Scripts/QuestionComposerScripts.js"));

            //if (_question != null)
            //{
            //    QuestionContentTextBox.Text = _question.Content;
            //    foreach (var control in _answerControls)
            //    {
            //        control.AnswerContent = _question.QuestionAnswers.ElementAt(_answerControls.IndexOf(control)).Content;
            //        control.FractionValue = _question.QuestionAnswers.ElementAt(_answerControls.IndexOf(control)).Fraction.ToString() + "%";
            //    }
            //}

            Controls.Add(_questionLabel);
            Controls.Add(_questionContentTextBox);

            for (int i = 0; i < AnswerCount; ++i)
            {
                var control = new QuestionAnswerControl()
                    {
                        AnswerLabelText = AnswerLabelText,
                        FractionLabelText = FractionLabelText
                    };

                _answerControls.Add(control);
                Controls.Add(control);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (!Page.IsPostBack)
            {
                var fractions = new Collection<ListItem>();
                for (int fractionValue = -100; fractionValue <= 100; fractionValue += 5)
                {
                    fractions.Add(new ListItem(fractionValue.ToString()));
                }

                fractions.Add(new ListItem("11,111"));
                fractions.Add(new ListItem("12,5"));
                fractions.Add(new ListItem("14,2857"));
                fractions.Add(new ListItem("16,666"));
                fractions.Add(new ListItem("33,333"));
                fractions.Add(new ListItem("66,666"));
                fractions.Add(new ListItem("83,333"));
                fractions.Add(new ListItem("-11,111"));
                fractions.Add(new ListItem("-12,5"));
                fractions.Add(new ListItem("-14,2857"));
                fractions.Add(new ListItem("-16,666"));
                fractions.Add(new ListItem("-33,333"));
                fractions.Add(new ListItem("-66,666"));
                fractions.Add(new ListItem("-83,333"));

                foreach (var control in _answerControls)
                {
                    control.FractionDropDownDataSource = fractions.OrderByDescending(item => DoubleHelper.Parse(item.Text));
                    control.DataBind();
                }
            }
        }

        #endregion
    }
}