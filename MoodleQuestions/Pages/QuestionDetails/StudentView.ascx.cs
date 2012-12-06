using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoodleQuestions.Controls;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public partial class StudentView : UserControl, IStudentView
    {
        #region Fields

        private StudentPresenter _presenter;
        private QuestionComposer _questionComposer;

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

        public QuestionComposer QuestionComposer
        {
            get 
            {
                if (_questionComposer == null)
                    _questionComposer = new QuestionComposer();
                return _questionComposer; 
            }
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
            _presenter.SetQuestionContent();
            if (_questionComposer != null)
                QuestionEditorPlaceHolder.Controls.Add(_questionComposer);
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            _presenter.SaveChanges();
        }

        #endregion
    }
}