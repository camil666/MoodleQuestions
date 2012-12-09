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
        #region Fields

        private Button _deleteButton;

        #endregion

        #region Properties

        public bool IsEditable { get; set; }

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
            _deleteButton = new Button()
            {
                Text = HttpContext.GetGlobalResourceObject("Strings", "DeleteButtonText").ToString()
            };

            _deleteButton.Click += DeleteButton_Click;
            SaveButton.Click += SaveButton_Click;
        }

        #endregion

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Controls.Add(_deleteButton);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SaveButton.Visible = IsEditable;
            _deleteButton.Visible = IsEditable;
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            (Presenter as StudentPresenter).SaveChanges();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}