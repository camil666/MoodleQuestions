using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoodleQuestions.Controls;
using QuestionsDAL;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public abstract class View<TPresenter> : WebControl, IView
        where TPresenter : IPresenter
    {
        #region Fields

        protected TableCell _ratingCell;
        protected TableCell _nameCell;
        private QuestionComposer _questionComposer;
        private TableCell _creationDateCell;
        private TableCell _authorCell;
        private Table _detailsTable;
        private Button _cancelButton;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the question id.
        /// </summary>
        /// <value>
        /// The question id.
        /// </value>
        public int QuestionId
        {
            get { return int.Parse(Page.Request.QueryString["q"]); }
        }

        /// <summary>
        /// Gets the changed question.
        /// </summary>
        /// <value>
        /// The changed question.
        /// </value>
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

        /// <summary>
        /// Gets or sets the question to display.
        /// </summary>
        /// <value>
        /// The question to display.
        /// </value>
        public Question QuestionToDisplay { get; set; }

        /// <summary>
        /// Gets or sets the presenter.
        /// </summary>
        /// <value>
        /// The presenter.
        /// </value>
        protected TPresenter Presenter { get; set; }

        /// <summary>
        /// Gets the question editor place holder.
        /// </summary>
        /// <value>
        /// The question editor place holder.
        /// </value>
        protected PlaceHolder QuestionEditorPlaceHolder { get; private set; }

        /// <summary>
        /// Gets the save button.
        /// </summary>
        /// <value>
        /// The save button.
        /// </value>
        protected Button SaveButton { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="View{TPresenter}" /> class.
        /// </summary>
        protected View()
            : base(HtmlTextWriterTag.Div)
        {
            _detailsTable = new Table();
            _ratingCell = new TableCell();
            _nameCell = new TableCell();
            _creationDateCell = new TableCell();
            _authorCell = new TableCell();
            SaveButton = new Button() { Text = ResourceHelper.GetString("SaveButtonText"), ValidationGroup = "Fractions" };
            _cancelButton = new Button() { Text = ResourceHelper.GetString("CancelButtonText"), PostBackUrl = "~/ManageQuestions.aspx" };
            QuestionEditorPlaceHolder = new PlaceHolder();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            AddRow(_nameCell, ResourceHelper.GetString("NameLabelText"));
            AddRow(_authorCell, ResourceHelper.GetString("AuthorLabelText"));
            AddRow(_creationDateCell, ResourceHelper.GetString("CreationDateLabelText"));
            AddRow(_ratingCell, ResourceHelper.GetString("RatingLabelText"));

            Controls.Add(_detailsTable);
            Controls.Add(QuestionEditorPlaceHolder);
            Controls.Add(SaveButton);
            Controls.Add(_cancelButton);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Load" /> event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                base.OnLoad(e);
                Page.ClientScript.RegisterClientScriptInclude("QuestionDetailsScripts", ResolveClientUrl("~/Scripts/QuestionDetailsScripts.js"));
                Presenter.SetQuestion();

                _creationDateCell.Text = QuestionToDisplay.CreationDate.ToString();
                if (QuestionToDisplay.Author != null)
                {
                    _authorCell.Text = QuestionToDisplay.Author.FirstName + " " + QuestionToDisplay.Author.LastName;
                }
            }
            catch (Exception)
            {
                Page.Response.Redirect("~/");
            }
        }

        /// <summary>
        /// Adds the row to the table.
        /// </summary>
        /// <param name="cell">The content cell.</param>
        /// <param name="labelText">The label text.</param>
        protected void AddRow(TableCell cell, string labelText)
        {
            var row = new TableRow();
            row.Cells.Add(new TableCell() { Text = labelText });
            row.Cells.Add(cell);
            _detailsTable.Rows.Add(row);
        }

        /// <summary>
        /// Initializes the question viewer.
        /// </summary>
        protected void InitializeQuestionViewer()
        {
            QuestionEditorPlaceHolder.Controls.Add(new QuestionViewer()
            {
                Question = QuestionToDisplay
            });
        }

        /// <summary>
        /// Initializes the question composer.
        /// </summary>
        protected void InitializeQuestionComposer()
        {
            _questionComposer = new QuestionComposer()
            {
                QuestionLabelText = ResourceHelper.GetString("QuestionLabelText"),
                AnswerLabelText = ResourceHelper.GetString("AnswerLabelText"),
                FractionLabelText = ResourceHelper.GetString("FractionLabelText"),
                ValidatorErrorMessage = ResourceHelper.GetString("FractionValidatorErrorMessage"),
                IsVisibleLabelText = ResourceHelper.GetString("IsVisibleLabelText"),
                Question = QuestionToDisplay,
                FractionsValidationGroup = "Fractions"
            };

            QuestionEditorPlaceHolder.Controls.Add(_questionComposer);
        }

        #endregion
    }
}