﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public partial class StudentView : UserControl, IStudentView
    {
        #region Fields

        private StudentPresenter _presenter;

        #endregion

        #region Properties

        public int QuestionId
        {
            get { return int.Parse(Request.QueryString[Constants.QuestionIdQueryString]); }
        }

        public string QuestionCreationDate
        {
            get { return CreationDateCell.Text; }
            set { CreationDateCell.Text = value; }
        }

        public string QuestionAuthor
        {
            get { return AuthorCell.Text; }
            set { AuthorCell.Text = value; }
        }

        public string QuestionRating
        {
            get { return RatingCell.Text; }
            set { RatingCell.Text = value.ToString(); }
        }

        #endregion

        #region Constructors

        public StudentView()
        {
            _presenter = new StudentPresenter(this);
        }

        #endregion

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter.SetQuestionDetails();
        }

        #endregion
    }
}