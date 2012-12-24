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
        protected TableCell _typeCell;
        protected QuestionComposer _questionComposer;
        private TableCell _creationDateCell;
        private TableCell _authorCell;

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
            get { return int.Parse(Page.Request.QueryString[Constants.QuestionIdQueryString]); }
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
        /// Gets the details table.
        /// </summary>
        /// <value>
        /// The details table.
        /// </value>
        protected Table DetailsTable { get; private set; }

        /// <summary>
        /// Gets the cancel button.
        /// </summary>
        /// <value>
        /// The cancel button.
        /// </value>
        protected Button CancelButton { get; private set; }

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
            DetailsTable = new Table();
            SaveButton = new Button() { Text = HttpContext.GetGlobalResourceObject("Strings", "SaveButtonText").ToString(), ValidationGroup = "Fractions" };
            CancelButton = new Button() { Text = HttpContext.GetGlobalResourceObject("Strings", "CancelButtonText").ToString(), PostBackUrl = "~/ManageQuestions.aspx" };
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

            var nameRow = new TableRow();
            nameRow.Cells.Add(new TableCell() { Text = HttpContext.GetGlobalResourceObject("Strings", "NameLabelText").ToString() });
            _nameCell = new TableCell();
            nameRow.Cells.Add(_nameCell);
            DetailsTable.Rows.Add(nameRow);

            var authorRow = new TableRow();
            authorRow.Cells.Add(new TableCell() { Text = HttpContext.GetGlobalResourceObject("Strings", "AuthorLabelText").ToString() });
            _authorCell = new TableCell();
            authorRow.Cells.Add(_authorCell);
            DetailsTable.Rows.Add(authorRow);

            var creationDateRow = new TableRow();
            creationDateRow.Cells.Add(new TableCell() { Text = HttpContext.GetGlobalResourceObject("Strings", "CreationDateLabelText").ToString() });
            _creationDateCell = new TableCell();
            creationDateRow.Cells.Add(_creationDateCell);
            DetailsTable.Rows.Add(creationDateRow);

            var typeRow = new TableRow();
            typeRow.Cells.Add(new TableCell() { Text = HttpContext.GetGlobalResourceObject("Strings", "TypeLabelText").ToString() });
            _typeCell = new TableCell();
            typeRow.Cells.Add(_typeCell);
            DetailsTable.Rows.Add(typeRow);

            var ratingRow = new TableRow();
            ratingRow.Cells.Add(new TableCell() { Text = HttpContext.GetGlobalResourceObject("Strings", "RatingLabelText").ToString() });
            _ratingCell = new TableCell();
            ratingRow.Cells.Add(_ratingCell);
            DetailsTable.Rows.Add(ratingRow);

            Controls.Add(DetailsTable);
            Controls.Add(QuestionEditorPlaceHolder);
            Controls.Add(SaveButton);
            Controls.Add(CancelButton);
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
                    _authorCell.Text = QuestionToDisplay.Author.UserName;
                }

                if (QuestionToDisplay.QuestionType != null && !string.IsNullOrEmpty(QuestionToDisplay.QuestionType.Name))
                {
                    _typeCell.Text = QuestionToDisplay.QuestionType.Name;
                }
                else
                {
                    _typeCell.Text = string.Empty;
                }
            }
            catch (Exception)
            {
                Page.Response.Redirect("~/");
            }
        }

        #endregion
    }
}