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
    public partial class AnonymousUserView : UserControl, IView
    {
        #region Fields

        private AnonymousUserPresenter _presenter;
        private QuestionComposer _questionComposerControl;

        #endregion

        #region Constructors

        public AnonymousUserView()
        {
            _presenter = new AnonymousUserPresenter(this);
        }

        #endregion

        #region IView Methods

        public Question GetQuestion()
        {
            return _questionComposerControl.GetQuestion();
        }

        #endregion

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            _questionComposerControl = LoadControl("~/Controls/QuestionComposer.ascx") as QuestionComposer;
            _questionComposerControl.AnswerCount = int.Parse(AnswerCountDropDown.SelectedValue);
            _questionComposerControl.AnswerLabelText = GetLocalResourceObject("QuestionAnswerControl.AnswerLabel.Text").ToString();
            _questionComposerControl.FractionLabelText = GetLocalResourceObject("QuestionAnswerControl.FractionLabel.Text").ToString();
            _questionComposerControl.ValidationErrorMessage = GetLocalResourceObject("QuestionAnswerControl.ValidationErrorMessage").ToString();

            QuestionComposerPlaceHolder.Controls.Add(_questionComposerControl);
        }

        protected void GenerateXMLButton_Click(object sender, EventArgs e)
        {
            var xml = _presenter.GenerateXML();
            Response.ContentType = "text/xml";
            Response.AppendHeader("content-disposition", "attachment;filename=Question.xml");
            xml.Save(Response.OutputStream);
            Response.End();
        }

        #endregion
    }
}