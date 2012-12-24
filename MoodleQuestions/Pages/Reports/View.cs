using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoodleQuestions.Controls;

namespace MoodleQuestions.Pages.Reports
{
    public abstract class View<TPresenter> : WebControl, IView
        where TPresenter : IPresenter
    {
        #region Fields

        private TableCell _questionCountCell;
        private TableCell _ratedQuestionCountCell;
        private TableCell _unratedQuestionCountCell;
        private TableCell _ratingCell;
        private DateFilter _dateFilter;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the selected student id.
        /// </summary>
        /// <value>
        /// The selected student id.
        /// </value>
        public virtual Guid SelectedStudentId
        {
            get { return Guid.Empty; }
        }

        /// <summary>
        /// Sets the question count.
        /// </summary>
        /// <value>
        /// The question count.
        /// </value>
        public string QuestionCount
        {
            set { _questionCountCell.Text = value; }
        }

        /// <summary>
        /// Sets the rated question count.
        /// </summary>
        /// <value>
        /// The rated question count.
        /// </value>
        public string RatedQuestionCount
        {
            set { _ratedQuestionCountCell.Text = value; }
        }

        /// <summary>
        /// Sets the unrated question count.
        /// </summary>
        /// <value>
        /// The unrated question count.
        /// </value>
        public string UnratedQuestionCount
        {
            set { _unratedQuestionCountCell.Text = value; }
        }

        /// <summary>
        /// Sets the average rating.
        /// </summary>
        /// <value>
        /// The average rating.
        /// </value>
        public string AverageRating
        {
            set { _ratingCell.Text = value; }
        }

        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public DateTime? StartDate
        {
            get { return _dateFilter.StartDate; }
        }

        /// <summary>
        /// Gets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public DateTime? EndDate
        {
            get { return _dateFilter.EndDate; }
        }

        /// <summary>
        /// Gets or sets the presenter.
        /// </summary>
        /// <value>
        /// The presenter.
        /// </value>
        protected TPresenter Presenter { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="View{TPresenter}" /> class.
        /// </summary>
        protected View()
            : base(HtmlTextWriterTag.Div)
        {
            _dateFilter = new DateFilter();
            _questionCountCell = new TableCell();
            _ratedQuestionCountCell = new TableCell();
            _unratedQuestionCountCell = new TableCell();
            _ratingCell = new TableCell();
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
            Controls.Add(_dateFilter);

            var searchButton = new Button()
            {
                Text = HttpContext.GetGlobalResourceObject("Strings", "SearchButtonText").ToString()
            };

            searchButton.Click += SearchButton_Click;
            Controls.Add(searchButton);

            var detailsTable = new Table();
            AddRow(_questionCountCell, HttpContext.GetGlobalResourceObject("Strings", "QuestionCountLabelText").ToString(), detailsTable);
            AddRow(_ratedQuestionCountCell, HttpContext.GetGlobalResourceObject("Strings", "RatedQuestionCountLabelText").ToString(), detailsTable);
            AddRow(_unratedQuestionCountCell, HttpContext.GetGlobalResourceObject("Strings", "UnratedQuestionCountLabelText").ToString(), detailsTable);
            AddRow(_ratingCell, HttpContext.GetGlobalResourceObject("Strings", "AverageRatingLabelText").ToString(), detailsTable);

            //var questionCountRow = new TableRow();
            //detailsTable.Rows.Add(questionCountRow);
            //questionCountRow.Cells.Add(new TableCell() { Text = HttpContext.GetGlobalResourceObject("Strings", "QuestionCountLabelText").ToString() });
            //_questionCountCell = new TableCell();
            //questionCountRow.Cells.Add(_questionCountCell);

            //var ratedQuestionCountRow = new TableRow();
            //detailsTable.Rows.Add(ratedQuestionCountRow);
            //ratedQuestionCountRow.Cells.Add(new TableCell() { Text = HttpContext.GetGlobalResourceObject("Strings", "RatedQuestionCountLabelText").ToString() });
            //_ratedQuestionCountCell = new TableCell();
            //ratedQuestionCountRow.Cells.Add(_ratedQuestionCountCell);

            //var unratedQuestionCountRow = new TableRow();
            //detailsTable.Rows.Add(unratedQuestionCountRow);
            //unratedQuestionCountRow.Cells.Add(new TableCell() { Text = HttpContext.GetGlobalResourceObject("Strings", "UnratedQuestionCountLabelText").ToString() });
            //_unratedQuestionCountCell = new TableCell();
            //unratedQuestionCountRow.Cells.Add(_unratedQuestionCountCell);

            //var ratingRow = new TableRow();
            //detailsTable.Rows.Add(ratingRow);
            //ratingRow.Cells.Add(new TableCell() { Text = HttpContext.GetGlobalResourceObject("Strings", "AverageRatingLabelText").ToString() });
            //_ratingCell = new TableCell();
            //ratingRow.Cells.Add(_ratingCell);

            Controls.Add(detailsTable);
        }

        private void AddRow(TableCell cell, string labelText, Table table)
        {
            var row = new TableRow();
            row.Cells.Add(new TableCell() { Text = labelText });
            row.Cells.Add(cell);
            table.Rows.Add(row);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            Presenter.DisplayUserReport();
        }

        #endregion
    }
}