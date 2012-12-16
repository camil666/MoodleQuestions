using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoodleQuestions.Controls;
using QuestionsDAL;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public class StudentView : BaseView, IStudentView
    {
        #region Fields

        private Button _deleteButton;
        private QuestionComposer _questionComposer;
        private CheckBox _isVisibleCheckbox;

        #endregion

        #region Properties

        public Question ChangedQuestion
        {
            get
            {
                if (_questionComposer != null)
                {
                    return _questionComposer.Question;
                }

                return null;
            }
        }

        public bool QuestionIsVisible
        {
            get
            {
                return _isVisibleCheckbox.Checked;
            }
        }

        #endregion

        #region Constructors

        public StudentView()
        {
            Presenter = new StudentPresenter(this);
            _deleteButton = new Button()
            {
                Text = HttpContext.GetGlobalResourceObject("Strings", "DeleteButtonText").ToString(),
                OnClientClick = "if (!ConfirmDelete()) { return false; };"
            };

            _deleteButton.Click += DeleteButton_Click;
            SaveButton.Click += SaveButton_Click;
        }

        #endregion

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Controls.Add(_deleteButton);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Page.ClientScript.RegisterClientScriptInclude("QuestionDetailsScripts", ResolveClientUrl("~/Scripts/QuestionDetailsScripts.js"));

            var isEditable = QuestionToDisplay.Rating == null;

            _deleteButton.Visible = isEditable;
            if (isEditable)
            {
                _questionComposer = new QuestionComposer()
                    {
                        QuestionLabelText = HttpContext.GetGlobalResourceObject("Strings", "QuestionLabelText").ToString(),
                        AnswerLabelText = HttpContext.GetGlobalResourceObject("Strings", "AnswerLabelText").ToString(),
                        FractionLabelText = HttpContext.GetGlobalResourceObject("Strings", "FractionLabelText").ToString(),
                        ValidatorErrorMessage = HttpContext.GetGlobalResourceObject("Strings", "FractionValidatorErrorMessage").ToString(),
                        IsVisibleLabelText = HttpContext.GetGlobalResourceObject("Strings", "IsVisibleLabelText").ToString(),
                        Question = QuestionToDisplay,
                        FractionsValidationGroup = "Fractions"
                    };

                QuestionEditorPlaceHolder.Controls.Add(_questionComposer);
            }
            else
            {
                _isVisibleCheckbox = new CheckBox()
                {
                    Text = HttpContext.GetGlobalResourceObject("Strings", "IsVisibleLabelText").ToString(),
                    TextAlign = TextAlign.Left
                };

                _isVisibleCheckbox.LabelAttributes.CssStyle.Add(HtmlTextWriterStyle.Display, "inline");
                _isVisibleCheckbox.LabelAttributes.CssStyle.Add(HtmlTextWriterStyle.MarginRight, "5px");
                _isVisibleCheckbox.LabelAttributes.CssStyle.Add(HtmlTextWriterStyle.FontWeight, "normal");
                _isVisibleCheckbox.LabelAttributes.CssStyle.Add(HtmlTextWriterStyle.FontSize, "1em");
                _isVisibleCheckbox.Checked = QuestionToDisplay.IsVisible;

                QuestionEditorPlaceHolder.Controls.Add(new LiteralControl("<br>"));
                QuestionEditorPlaceHolder.Controls.Add(_isVisibleCheckbox);
                QuestionEditorPlaceHolder.Controls.Add(new QuestionViewer()
                    {
                        Question = QuestionToDisplay
                    });
            }

            if (QuestionToDisplay.Rating != null)
            {
                _ratingCell.Text = QuestionToDisplay.Rating.Value.ToString();
            }
            else
            {
                _ratingCell.Text = Constants.EmptyText;
            }

            if (!string.IsNullOrEmpty(QuestionToDisplay.Name))
            {
                _nameCell.Text = QuestionToDisplay.Name;
            }
            else
            {
                _nameCell.Text = string.Empty;
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            (Presenter as StudentPresenter).SaveChanges();
            Page.Response.Redirect("~/ManageQuestions.aspx");
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            (Presenter as StudentPresenter).DeleteQuestion(QuestionId);
            Page.Response.Redirect("~/ManageQuestions.aspx");
        }

        #endregion
    }
}