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
    public class AnonymousUserView : WebControl, IView
    {
        #region Fields

        private AnonymousUserPresenter _presenter;
        private QuestionComposer _questionComposerControl;
        private Label _answerCountLabel;
        private DropDownList _answerCountDropDown;
        private Button _generateXmlButton;

        #endregion

        #region Constructors

        public AnonymousUserView()
            : base(HtmlTextWriterTag.Div)
        {
            _presenter = new AnonymousUserPresenter(this);
        }

        #endregion

        #region IView Methods

        public Question GetQuestion()
        {
            return _questionComposerControl.Question;
        }

        #endregion

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            _answerCountLabel = new Label()
            {
                Text = HttpContext.GetGlobalResourceObject("Strings", "AnswerCountDropDownLabel").ToString()
            };

            Controls.Add(_answerCountLabel);

            _answerCountDropDown = new DropDownList()
            {
                AutoPostBack = true
            };

            if (!Page.IsPostBack)
            {
                _answerCountDropDown.DataSource = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10" };
                _answerCountDropDown.DataBind();
                _answerCountDropDown.Items.FindByText("4").Selected = true;
            }

            Controls.Add(_answerCountDropDown);

            _questionComposerControl = new QuestionComposer()
            {
                AnswerCount = int.Parse(_answerCountDropDown.SelectedValue),
                QuestionLabelText = HttpContext.GetGlobalResourceObject("Strings", "QuestionLabelText").ToString(),
                AnswerLabelText = HttpContext.GetGlobalResourceObject("Strings", "AnswerLabelText").ToString(),
                FractionLabelText = HttpContext.GetGlobalResourceObject("Strings", "FractionLabelText").ToString(),
                ValidatorErrorMessage = HttpContext.GetGlobalResourceObject("Strings", "FractionValidatorErrorMessage").ToString()
            };

            Controls.Add(_questionComposerControl);

            _generateXmlButton = new Button()
            {
                Text = HttpContext.GetGlobalResourceObject("Strings", "GenerateXMLButtonText").ToString()
            };

            _generateXmlButton.Click += GenerateXMLButton_Click;
            Controls.Add(_generateXmlButton);
        }

        protected void GenerateXMLButton_Click(object sender, EventArgs e)
        {
            var xml = _presenter.GenerateXML();
            Page.Response.ContentType = "text/xml";
            Page.Response.AppendHeader("content-disposition", "attachment;filename=Question.xml");
            xml.Save(Page.Response.OutputStream);
            Page.Response.End();
        }

        #endregion
    }
}