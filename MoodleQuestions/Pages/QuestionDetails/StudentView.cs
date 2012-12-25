using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoodleQuestions.Controls;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public class StudentView : View<StudentPresenter>, IStudentView
    {
        #region Fields

        private Button _deleteButton;
        private CheckBox _isVisibleCheckbox;

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether question is visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if question is visible; otherwise, <c>false</c>.
        /// </value>
        public bool QuestionIsVisible
        {
            get
            {
                return _isVisibleCheckbox.Checked;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentView" /> class.
        /// </summary>
        public StudentView()
        {
            Presenter = new StudentPresenter(this);
            _deleteButton = new Button()
            {
                Text = ResourceHelper.GetString("DeleteButtonText"),
                OnClientClick = "if (!ConfirmDelete()) { return false; };"
            };

            _deleteButton.Click += DeleteButton_Click;
            SaveButton.Click += SaveButton_Click;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Raises the <see cref="E:Init" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Controls.Add(_deleteButton);
        }

        /// <summary>
        /// Raises the <see cref="E:Load" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var isEditable = QuestionToDisplay.Rating == null;

            _deleteButton.Visible = isEditable;

            if (isEditable)
            {
                InitializeQuestionComposer();
            }
            else
            {
                _isVisibleCheckbox = new CheckBox()
                {
                    Text = ResourceHelper.GetString("IsVisibleLabelText"),
                    TextAlign = TextAlign.Left,
                    Checked = QuestionToDisplay.IsVisible
                };

                _isVisibleCheckbox.LabelAttributes.CssStyle.Add(HtmlTextWriterStyle.Display, "inline");
                _isVisibleCheckbox.LabelAttributes.CssStyle.Add(HtmlTextWriterStyle.MarginRight, "5px");
                _isVisibleCheckbox.LabelAttributes.CssStyle.Add(HtmlTextWriterStyle.FontWeight, "normal");
                _isVisibleCheckbox.LabelAttributes.CssStyle.Add(HtmlTextWriterStyle.FontSize, "1em");

                QuestionEditorPlaceHolder.Controls.Add(new LiteralControl("<br>"));
                QuestionEditorPlaceHolder.Controls.Add(_isVisibleCheckbox);
                InitializeQuestionViewer();
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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Presenter.SaveChanges();
            Page.Response.Redirect("~/ManageQuestions.aspx");
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Presenter.DeleteQuestion(QuestionId);
            Page.Response.Redirect("~/ManageQuestions.aspx");
        }

        #endregion
    }
}