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
    public class BaseView : WebControl, IView
    {
        #region Fields

        private BasePresenter _presenter;
        private Label _answerCountLabel;
        private DropDownList _answerCountDropDown;
        private Button _generateXmlButton;

        #endregion

        #region Properties

        protected QuestionComposer QuestionComposerControl;

        #endregion

        #region Constructors

        public BaseView()
            : base(HtmlTextWriterTag.Div)
        {
            _presenter = new BasePresenter(this);
            _answerCountLabel = new Label()
            {
                Text = HttpContext.GetGlobalResourceObject("Strings", "AnswerCountDropDownLabel").ToString()
            };

            _answerCountDropDown = new DropDownList()
            {
                AutoPostBack = true
            };

            QuestionComposerControl = new QuestionComposer()
            {
                QuestionLabelText = HttpContext.GetGlobalResourceObject("Strings", "QuestionLabelText").ToString(),
                AnswerLabelText = HttpContext.GetGlobalResourceObject("Strings", "AnswerLabelText").ToString(),
                FractionLabelText = HttpContext.GetGlobalResourceObject("Strings", "FractionLabelText").ToString(),
                ValidatorErrorMessage = HttpContext.GetGlobalResourceObject("Strings", "FractionValidatorErrorMessage").ToString(),
                IsVisibleLabelText = HttpContext.GetGlobalResourceObject("Strings", "IsVisibleLabelText").ToString()
            };

            _generateXmlButton = new Button()
            {
                Text = HttpContext.GetGlobalResourceObject("Strings", "GenerateXMLButtonText").ToString()
            };

            _generateXmlButton.Click += GenerateXMLButton_Click;
        }

        #endregion

        #region IView Methods

        public Question GetQuestion()
        {
            return QuestionComposerControl.Question;
        }

        #endregion

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Controls.Add(_answerCountLabel);
            Controls.Add(_answerCountDropDown);
            Controls.Add(QuestionComposerControl);
            Controls.Add(_generateXmlButton);

            if (!Page.IsPostBack)
            {
                _answerCountDropDown.DataSource = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10" };
                _answerCountDropDown.DataBind();
                _answerCountDropDown.Items.FindByText("4").Selected = true;
            }  
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            QuestionComposerControl.AnswerCount = int.Parse(_answerCountDropDown.SelectedValue);
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