using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoodleQuestions.Pages.Raports
{
    public class View : WebControl, IView
    {
        #region Fields

        private DropDownList _userDropDown;
        private Presenter _presenter;
        private TextBox _startDateTextBox;
        private TextBox _endDateTextBox;
        private TableCell _questionCountCell;
        private TableCell _ratedQuestionCountCell;
        private TableCell _unratedQuestionCountCell;
        private TableCell _ratingCell;

        #endregion

        #region Properties

        public string QuestionCount
        {
            set { _questionCountCell.Text = value; }
        }

        public string RatedQuestionCount
        {
            set { _ratedQuestionCountCell.Text = value; }
        }

        public string UnratedQuestionCount
        {
            set { _unratedQuestionCountCell.Text = value; }
        }

        public string AverageRating
        {
            set { _ratingCell.Text = value; }
        }

        public object DropDownDataSource
        {
            get { return _userDropDown.DataSource; }
            set { _userDropDown.DataSource = value; }
        }

        public Guid SelectedStudentId
        {
            get
            {
                return Guid.Parse(_userDropDown.SelectedItem.Value);
            }
        }

        public DateTime? StartDate
        {
            get
            {
                DateTime date;
                if (DateTime.TryParse(_startDateTextBox.Text, out date) == true)
                {
                    return date;
                }

                return null;
            }
        }

        public DateTime? EndDate
        {
            get
            {
                DateTime date;
                if (DateTime.TryParse(_endDateTextBox.Text, out date) == true)
                {
                    return date;
                }

                return null;
            }
        }

        #endregion

        #region Constructors

        public View()
            : base(HtmlTextWriterTag.Div)
        {
            _userDropDown = new DropDownList()
            {
                DataTextField = "FullName",
                DataValueField = "Id"
            };

            _startDateTextBox = new TextBox() { ID = "startDateTextBox", ClientIDMode = ClientIDMode.Static, ReadOnly = true };
            _endDateTextBox = new TextBox() { ID = "endDateTextBox", ClientIDMode = ClientIDMode.Static, ReadOnly = true };
            _presenter = new Presenter(this);
            //_validator = new CustomValidator()
            //{
            //    Display = ValidatorDisplay.Dynamic,
            //    ClientValidationFunction = "Answers.ValidateSum"
            //};
        }

        #endregion

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Controls.Add(new Label() { Text = HttpContext.GetGlobalResourceObject("Strings", "AuthorLabelText").ToString() });
            Controls.Add(_userDropDown);
            Controls.Add(new Label() { Text = HttpContext.GetGlobalResourceObject("Strings", "StartDateLabelText").ToString() });
            Controls.Add(_startDateTextBox);
            Controls.Add(new Label() { Text = HttpContext.GetGlobalResourceObject("Strings", "EndDateLabelText").ToString() });
            Controls.Add(_endDateTextBox);

            var searchButton = new Button()
            {
                Text = HttpContext.GetGlobalResourceObject("Strings", "SearchButtonText").ToString()
            };

            Controls.Add(searchButton);

            var detailsTable = new Table();

            var questionCountRow = new TableRow();
            detailsTable.Rows.Add(questionCountRow);
            questionCountRow.Cells.Add(new TableCell() { Text = HttpContext.GetGlobalResourceObject("Strings", "QuestionCountLabelText").ToString() });
            _questionCountCell = new TableCell();
            questionCountRow.Cells.Add(_questionCountCell);

            var ratedQuestionCountRow = new TableRow();
            detailsTable.Rows.Add(ratedQuestionCountRow);
            ratedQuestionCountRow.Cells.Add(new TableCell() { Text = HttpContext.GetGlobalResourceObject("Strings", "RatedQuestionCountLabelText").ToString() });
            _ratedQuestionCountCell = new TableCell();
            ratedQuestionCountRow.Cells.Add(_ratedQuestionCountCell);

            var unratedQuestionCountRow = new TableRow();
            detailsTable.Rows.Add(unratedQuestionCountRow);
            unratedQuestionCountRow.Cells.Add(new TableCell() { Text = HttpContext.GetGlobalResourceObject("Strings", "UnratedQuestionCountLabelText").ToString() });
            _unratedQuestionCountCell = new TableCell();
            unratedQuestionCountRow.Cells.Add(_unratedQuestionCountCell);

            var ratingRow = new TableRow();
            detailsTable.Rows.Add(ratingRow);
            ratingRow.Cells.Add(new TableCell() { Text = HttpContext.GetGlobalResourceObject("Strings", "AverageRatingLabelText").ToString() });
            _ratingCell = new TableCell();
            ratingRow.Cells.Add(_ratingCell);

            Controls.Add(detailsTable);

            if (!Page.IsPostBack)
            {
                _presenter.SetupDropDown();
                _userDropDown.DataBind();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Page.ClientScript.RegisterClientScriptInclude("DatePickersScripts", ResolveClientUrl("~/Scripts/DatePickersScripts.js"));

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            _presenter.DisplayUserReport();
        }

        #endregion
    }
}