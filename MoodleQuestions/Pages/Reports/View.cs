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
                Text = ResourceHelper.GetString("SearchButtonText")
            };

            searchButton.Click += SearchButton_Click;
            Controls.Add(searchButton);

            var detailsTable = new Table();
            AddRow(_questionCountCell, ResourceHelper.GetString("QuestionCountLabelText"), detailsTable);
            AddRow(_ratedQuestionCountCell, ResourceHelper.GetString("RatedQuestionCountLabelText"), detailsTable);
            AddRow(_unratedQuestionCountCell, ResourceHelper.GetString("UnratedQuestionCountLabelText"), detailsTable);
            AddRow(_ratingCell, ResourceHelper.GetString("AverageRatingLabelText"), detailsTable);

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