using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using MoodleQuestions.Controls;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public class StudentView : BaseView, IStudentView
    {
        #region Properties

        public string QuestionRating
        {
            get { return _ratingCell.Text; }
            set { _ratingCell.Text = value.ToString(); }
        }

        #endregion

        #region Constructors

        public StudentView()
        {
            Presenter = new StudentPresenter(this);
        }

        #endregion

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            SaveButton.Click += SaveButton_Click;
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            (Presenter as StudentPresenter).SaveChanges();
        }

        #endregion
    }
}