using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoodleQuestions.Controls;
using QuestionsDAL;

namespace MoodleQuestions.Pages.CreateQuestion
{
    public abstract class View : WebControl, IView
    {
        #region Fields

        private Label _answerCountLabel;
        private DropDownList _answerCountDropDown;
        private Button _generateXmlButton;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the presenter.
        /// </summary>
        /// <value>
        /// The presenter.
        /// </value>
        protected Presenter Presenter { get; set; }

        /// <summary>
        /// Gets or sets the question composer control.
        /// </summary>
        /// <value>
        /// The question composer control.
        /// </value>
        protected QuestionComposer QuestionComposerControl { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="View" /> class.
        /// </summary>
        protected View()
            : base(HtmlTextWriterTag.Div)
        {
            Presenter = new Presenter(this);
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

        #region Methods

        /// <summary>
        /// Gets the question.
        /// </summary>
        /// <returns>
        /// Created question.
        /// </returns>
        public Question GetQuestion()
        {
            return QuestionComposerControl.Question;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
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

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Load" /> event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            QuestionComposerControl.AnswerCount = int.Parse(_answerCountDropDown.SelectedValue);
        }

        /// <summary>
        /// Handles the Click event of the GenerateXMLButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void GenerateXMLButton_Click(object sender, EventArgs e)
        {
            var xml = Presenter.GenerateXML();
            Page.Response.ContentType = "text/xml";
            Page.Response.AppendHeader("content-disposition", "attachment;filename=Question.xml");
            xml.Save(Page.Response.OutputStream);
            Page.Response.End();
        }

        #endregion
    }
}