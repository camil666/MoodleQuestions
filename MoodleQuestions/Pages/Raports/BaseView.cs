using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoodleQuestions.Pages.Raports
{
    public class BaseView : WebControl, IBaseView
    {
        #region Fields

        private BasePresenter _presenter;
        private TextBox _startDateTextBox;
        private TextBox _endDateTextBox;
        private TableCell _questionCountCell;
        private TableCell _ratedQuestionCountCell;
        private TableCell _unratedQuestionCountCell;
        private TableCell _ratingCell;

        #endregion

        #region Properties

        public virtual Guid SelectedStudentId
        {
            get { return Guid.Empty; }
        }

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

        public BaseView()
            : base(HtmlTextWriterTag.Div)
        {
            _startDateTextBox = new TextBox() { ID = "startDateTextBox", ClientIDMode = ClientIDMode.Static };
            _endDateTextBox = new TextBox() { ID = "endDateTextBox", ClientIDMode = ClientIDMode.Static };
            _presenter = new BasePresenter(this);
        }

        #endregion

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Controls.Add(new Label() { Text = HttpContext.GetGlobalResourceObject("Strings", "StartDateLabelText").ToString(), Width = 180 });
            Controls.Add(_startDateTextBox);
            Controls.Add(new LiteralControl("<br>"));
            Controls.Add(new Label() { Text = HttpContext.GetGlobalResourceObject("Strings", "EndDateLabelText").ToString(), Width = 180 });
            Controls.Add(_endDateTextBox);
            Controls.Add(new LiteralControl("<br>"));

            var searchButton = new Button()
            {
                Text = HttpContext.GetGlobalResourceObject("Strings", "SearchButtonText").ToString()
            };

            searchButton.Click += SearchButton_Click;
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
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Page.ClientScript.RegisterClientScriptInclude("DatePickersScripts", ResolveClientUrl("~/Scripts/DatePickersScripts.js"));
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            _presenter.DisplayUserReport();
        }

        #endregion
    }
}