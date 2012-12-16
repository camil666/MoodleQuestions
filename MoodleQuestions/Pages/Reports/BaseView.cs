using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoodleQuestions.Controls;

namespace MoodleQuestions.Pages.Reports
{
    public class BaseView : WebControl, IBaseView
    {
        #region Fields

        private BasePresenter _presenter;
        private TableCell _questionCountCell;
        private TableCell _ratedQuestionCountCell;
        private TableCell _unratedQuestionCountCell;
        private TableCell _ratingCell;
        private DateFilter _dateFilter;

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
            get { return _dateFilter.StartDate; }
        }

        public DateTime? EndDate
        {
            get { return _dateFilter.EndDate; }
        }

        #endregion

        #region Constructors

        public BaseView()
            : base(HtmlTextWriterTag.Div)
        {
            _dateFilter = new DateFilter();
            _presenter = new BasePresenter(this);
        }

        #endregion

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Controls.Add(_dateFilter);

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

        private void SearchButton_Click(object sender, EventArgs e)
        {
            _presenter.DisplayUserReport();
        }

        #endregion
    }
}