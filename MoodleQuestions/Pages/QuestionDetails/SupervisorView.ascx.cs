using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoodleQuestions.Pages.QuestionDetails
{//TODO: klasa bazowa dla obu widokow
    public partial class SupervisorView : UserControl, ISupervisorView
    {
        #region Fields

        private SupervisorPresenter _presenter;

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

        public string QuestionName
        {
            get { return NameCell.Text; }
            set { NameCell.Text = value; }
        }
        //TODO: przerobic na dropdown
        public string QuestionCategory
        {
            get { return CategoryCell.Text; }
            set { CategoryCell.Text = value; }
        }
        //TODO: przerobic na dropdown lub read-only text(do zastanowienia)
        public string QuestionType
        {
            get { return TypeCell.Text; }
            set { TypeCell.Text = value; }
        }

        public int? SelectedRating
        {
            get
            {
                int result;
                if (int.TryParse(RatingDropDown.SelectedItem.Text, out result) == true)
                    return result;
                else
                    return null;
            }
        }

        #endregion

        #region Constructors

        public SupervisorView()
        {
            _presenter = new SupervisorPresenter(this);
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