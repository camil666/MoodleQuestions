using System;
using System.Collections.Generic;
using System.Linq;
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
        private TableCell _creationDateCell;
        private TableCell _authorCell;

        #endregion

        #region Properties

        public int QuestionId
        {
            get { return int.Parse(Page.Request.QueryString[Constants.QuestionIdQueryString]); }
        }

        public Question QuestionToDisplay { get; set; }

        protected TPresenter Presenter { get; set; }

        protected PlaceHolder QuestionEditorPlaceHolder { get; private set; }

        protected Table DetailsTable { get; private set; }

        protected Button CancelButton { get; private set; }

        protected Button SaveButton { get; private set; }

        #endregion

        #region Constructors

        public View()
            : base(HtmlTextWriterTag.Div)
        {
            DetailsTable = new Table();
            SaveButton = new Button() { Text = HttpContext.GetGlobalResourceObject("Strings", "SaveButtonText").ToString() };
            CancelButton = new Button() { Text = HttpContext.GetGlobalResourceObject("Strings", "CancelButtonText").ToString(), PostBackUrl = "~/ManageQuestions.aspx" };
            QuestionEditorPlaceHolder = new PlaceHolder();
        }

        #endregion

        #region Methods

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

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                base.OnLoad(e);
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