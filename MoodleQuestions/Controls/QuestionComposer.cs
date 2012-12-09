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
        private Label _questionLabel;
        private CheckBox _isVisibleCheckbox;
        private CustomValidator _validator;
        private Question _question;

        #endregion

        #region Properties

        public bool AnonymousMode { get; set; }

        public bool IsVisible
        {
            get { return _isVisibleCheckbox.Checked; }
        }

        public string IsVisibleLabelText { get; set; }

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
                    Content = _questionContentTextBox.Text,
                    IsVisible = IsVisible
                };

                var user = Membership.GetUser();
                if (user != null)
                {
                    question.AuthorId = Guid.Parse(user.ProviderUserKey.ToString());
                }

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
                _question = value;
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
            _isVisibleCheckbox = new CheckBox();
            _validator = new CustomValidator()
            {
                Display = ValidatorDisplay.Dynamic,
                ClientValidationFunction = "Answers.ValidateSum"
            };
        }

        #endregion

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (AnonymousMode == false)
            {
                Controls.Add(new Label() { Text = IsVisibleLabelText });
                Controls.Add(_isVisibleCheckbox);
            }

            Controls.Add(_questionLabel);
            Controls.Add(_questionContentTextBox);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Page.ClientScript.RegisterClientScriptInclude("TinyMce", ResolveClientUrl("~/Scripts/tiny_mce/tiny_mce.js"));
            Page.ClientScript.RegisterClientScriptInclude("ComposerScripts", ResolveClientUrl("~/Scripts/QuestionComposerScripts.js"));
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (_question != null)
            {
                for (int i = 0; i < _question.QuestionAnswers.Count; ++i)
                {
                    _questionContentTextBox.Text = _question.Content;

                    var control = new QuestionAnswerControl()
                    {
                        AnswerLabelText = AnswerLabelText,
                        AnswerContent = _question.QuestionAnswers.ElementAt(i).Content,
                        FractionLabelText = FractionLabelText,
                        FractionValue = _question.QuestionAnswers.ElementAt(i).Fraction.ToString()
                    };

                    _answerControls.Add(control);
                    Controls.Add(control);
                }
            }
            else
            {
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