using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoodleQuestions.Controls;
using QuestionsDAL;

namespace MoodleQuestions
{
    public partial class CreateQuestion : Page
    {
        #region Constants

        private const string QuestionAnswerIdBase = "QuestionAnswer";

        #endregion

        #region Fields

        private Collection<QuestionAnswerControl> _answerControls;

        #endregion

        #region Methods

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (!IsPostBack)
            {
                var itemCollection = new Collection<ListItem>();
                for (int fractionValue = -100; fractionValue <= 100; fractionValue += 5)
                    itemCollection.Add(new ListItem(fractionValue.ToString()));

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
                    control.FractionDropDownDataSource = itemCollection.OrderByDescending(item => DoubleHelper.GetDouble(item.Text));
                    control.DataBind();
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var saveQuestionButton = new Button()
                {
                    ID = "SaveQuestionButton",
                    Text = GetLocalResourceObject("SaveQuestionButton.Text").ToString(),
                };

                saveQuestionButton.Click += SaveQuestionButton_Click;
                ButtonsPlaceHolder.Controls.Add(saveQuestionButton);
            }

            _answerControls = new Collection<QuestionAnswerControl>();

            for (int i = 0; i < int.Parse(AnswerCountDropDown.SelectedValue); ++i)
            {
                var questionControl = new QuestionAnswerControl()
                    {
                        ID = QuestionAnswerIdBase + i,
                        AnswerLabelText = string.Format(GetLocalResourceObject("QuestionAnswerControl.AnswerLabel.Text").ToString(), i + 1),
                        FractionLabelText = GetLocalResourceObject("QuestionAnswerControl.FractionLabel.Text").ToString(),
                        ValidationErrorMessage = GetLocalResourceObject("QuestionAnswerControl.ValidationErrorMessage").ToString()
                    };

                _answerControls.Add(questionControl);

                AnswersPlaceHolder.Controls.Add(questionControl);
            }
        }

        protected void SaveQuestionButton_Click(object sender, EventArgs e)
        {
            var question = CreateQuestionFromControls();

            using (var context = new Entities())
            {
                //foreach (var answer in question.QuestionAnswers)
                //{
                //    context.QuestionAnswers.Add(answer);
                //}

                //context.SaveChanges();

                context.Questions.Add(question);
                context.SaveChanges();
            }
        }

        protected void GenerateXMLButton_Click(object sender, EventArgs e)
        {
            var question = CreateQuestionFromControls();
            var xmlGenerator = new XmlGenerator();
            var xml = xmlGenerator.GenerateXml(question);

            Response.ContentType = "text/xml";
            Response.AppendHeader("content-disposition", "attachment;filename=Question.xml");
            xml.Save(Response.OutputStream);
            Response.End();
        }

        private Question CreateQuestionFromControls()
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
                question.QuestionAnswers.Add(new QuestionAnswer()
                {
                    Content = control.AnswerContent,
                    Fraction = DoubleHelper.GetDouble(control.FractionValue)
                });
            }

            return question;
        }

        #endregion
    }
}