using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoodleQuestions.Controls
{
    public class QuestionAnswerControl : WebControl
    {
        #region Constants

        private const string FractionTextBoxClass = "FractionDropDown";

        #endregion

        #region Fields

        private TextBox _answerTextBox;
        private DropDownList _fractionDropDown;
        private Label _answerLabel;
        private Label _fractionLabel;

        #endregion

        #region Properties

        public string AnswerContent
        {
            get { return _answerTextBox.Text; }
            set { _answerTextBox.Text = value; }
        }

        public string FractionValue
        {
            get { return _fractionDropDown.SelectedValue; }
            set { _fractionDropDown.Items.FindByText(value).Selected = true; }
        }

        public object FractionDropDownDataSource
        {
            get { return _fractionDropDown.DataSource; }
            set { _fractionDropDown.DataSource = value; }
        }

        public string AnswerLabelText
        {
            set { _answerLabel.Text = value; }
        }

        public string FractionLabelText
        {
            set { _fractionLabel.Text = value; }
        }

        public string ValidationErrorMessage { get; set; }

        #endregion

        #region Constructors

        public QuestionAnswerControl()
            : base(HtmlTextWriterTag.Div)
        {
            _fractionLabel = new Label();
            _answerLabel = new Label();
            _fractionDropDown = new DropDownList() { CssClass = FractionTextBoxClass };
            _answerTextBox = new TextBox
            {
                TextMode = TextBoxMode.MultiLine,
                CausesValidation = false
            };
        }

        #endregion

        #region Methods

        public override void DataBind()
        {
            base.DataBind();
            _fractionDropDown.DataBind();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Controls.Add(_answerLabel);
            Controls.Add(_answerTextBox);
            Controls.Add(_fractionLabel);
            Controls.Add(_fractionDropDown);
        }

        #endregion
    }
}