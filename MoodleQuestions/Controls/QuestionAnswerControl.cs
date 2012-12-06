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

        private const string FractionDropDownClass = "FractionDropDown";

        #endregion

        #region Fields

        private TextBox _answerTextBox;
        private DropDownList _fractionDropDown;
        private Label _answerLabel;
        private Label _fractionLabel;
        private string _fraction;

        #endregion

        #region Properties

        public string AnswerContent
        {
            get { return _answerTextBox.Text; }
            set { _answerTextBox.Text = value; }
        }

        public string AnswerLabelText
        {
            get { return _answerLabel.Text; }
            set { _answerLabel.Text = value; }
        }

        public string FractionValue
        {
            get { return _fractionDropDown.SelectedValue; }
            set { _fraction = value; }
        }

        public string FractionLabelText
        {
            get { return _fractionLabel.Text; }
            set { _fractionLabel.Text = value; }
        }

        public object FractionDropDownDataSource
        {
            get { return _fractionDropDown.DataSource; }
            set { _fractionDropDown.DataSource = value; }
        }

        #endregion

        #region Constructors

        public QuestionAnswerControl()
            : base(HtmlTextWriterTag.Div)
        {
            _fractionLabel = new Label();
            _answerLabel = new Label();
            _fractionDropDown = new DropDownList() { CssClass = "FractionDropDownClass" };
            _answerTextBox = new TextBox { TextMode = TextBoxMode.MultiLine };
        }

        #endregion

        #region Methods

        public override void DataBind()
        {
            base.DataBind();
            _fractionDropDown.DataBind();
            if (!string.IsNullOrEmpty(_fraction))
            {
                _fractionDropDown.Items.FindByText(_fraction).Selected = true;
            }
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