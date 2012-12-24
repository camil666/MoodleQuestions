using System;
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

        /// <summary>
        /// Gets or sets the content of the answer.
        /// </summary>
        /// <value>
        /// The content of the answer.
        /// </value>
        public string AnswerContent
        {
            get { return _answerTextBox.Text; }
            set { _answerTextBox.Text = value; }
        }

        /// <summary>
        /// Gets or sets the answer label text.
        /// </summary>
        /// <value>
        /// The answer label text.
        /// </value>
        public string AnswerLabelText
        {
            get { return _answerLabel.Text; }
            set { _answerLabel.Text = value; }
        }

        /// <summary>
        /// Gets or sets the fraction value.
        /// </summary>
        /// <value>
        /// The fraction value.
        /// </value>
        public string FractionValue
        {
            get { return _fractionDropDown.SelectedValue; }
            set { _fraction = value; }
        }

        /// <summary>
        /// Gets or sets the fraction label text.
        /// </summary>
        /// <value>
        /// The fraction label text.
        /// </value>
        public string FractionLabelText
        {
            get { return _fractionLabel.Text; }
            set { _fractionLabel.Text = value; }
        }

        /// <summary>
        /// Gets or sets the fraction drop down data source.
        /// </summary>
        /// <value>
        /// The fraction drop down data source.
        /// </value>
        public object FractionDropDownDataSource
        {
            get { return _fractionDropDown.DataSource; }
            set { _fractionDropDown.DataSource = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionAnswerControl" /> class.
        /// </summary>
        public QuestionAnswerControl()
            : base(HtmlTextWriterTag.Div)
        {
            _fractionLabel = new Label();
            _answerLabel = new Label();
            _fractionDropDown = new DropDownList() { CssClass = FractionDropDownClass };
            _answerTextBox = new TextBox { TextMode = TextBoxMode.MultiLine };
        }

        #endregion

        #region Methods

        /// <summary>
        /// Binds a data source to the invoked server control and all its child controls.
        /// </summary>
        public override void DataBind()
        {
            base.DataBind();
            _fractionDropDown.DataBind();
            if (!string.IsNullOrEmpty(_fraction))
            {
                _fractionDropDown.Items.FindByText(_fraction).Selected = true;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Controls.Add(_answerLabel);
            Controls.Add(_answerTextBox);
            Controls.Add(_fractionLabel);
            Controls.Add(_fractionDropDown);
        }

        #endregion
    }
}