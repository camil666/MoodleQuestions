using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoodleQuestions.Controls;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public abstract class BaseView : WebControl, IBaseView
    {
        #region Fields

        protected TableCell _ratingCell;
        protected TableCell _nameCell;
        protected TableCell _typeCell;
        private TableCell _creationDateCell;
        private TableCell _authorCell;
        private QuestionComposer _questionComposer;

        #endregion

        #region Properties

        public int QuestionId
        {
            get { return int.Parse(Page.Request.QueryString[Constants.QuestionIdQueryString]); }
        }

        public virtual string QuestionName
        {
            get { return _nameCell.Text; }
            set { _nameCell.Text = value; }
        }

        public string QuestionCreationDate
        {
            get { return _creationDateCell.Text; }
            set { _creationDateCell.Text = value; }
        }

        public string QuestionAuthor
        {
            get { return _authorCell.Text; }
            set { _authorCell.Text = value; }
        }

        public string QuestionType
        {
            get { return _typeCell.Text; }
            set { _typeCell.Text = value; }
        }

        public QuestionComposer QuestionComposer
        {
            get
            {
                if (_questionComposer == null)
                {
                    _questionComposer = new QuestionComposer()
                        {
                            QuestionLabelText = HttpContext.GetGlobalResourceObject("Strings", "QuestionLabelText").ToString(),
                            AnswerLabelText = HttpContext.GetGlobalResourceObject("Strings", "AnswerLabelText").ToString(),
                            FractionLabelText = HttpContext.GetGlobalResourceObject("Strings", "FractionLabelText").ToString(),
                            ValidatorErrorMessage = HttpContext.GetGlobalResourceObject("Strings", "FractionValidatorErrorMessage").ToString()
                        };
                }

                return _questionComposer;
            }
        }

        protected BasePresenter Presenter { get; set; }

        protected PlaceHolder QuestionEditorPlaceHolder { get; private set; }

        protected Table DetailsTable { get; private set; }

        protected Button CancelButton { get; private set; }

        protected Button SaveButton { get; private set; }

        #endregion

        #region Constructors

        public BaseView()
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
            base.OnLoad(e);
            Presenter.SetQuestionDetails();
            Presenter.SetQuestionContent();
            if (_questionComposer != null)
            {
                QuestionEditorPlaceHolder.Controls.Add(_questionComposer);
            }
        }

        #endregion
    }
}