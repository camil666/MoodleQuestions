using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoodleQuestions.Controls;

namespace MoodleQuestions.Pages.QuestionDetails
{//TODO: klasa bazowa dla obu widokow
    public partial class SupervisorView : UserControl, ISupervisorView
    {
        #region Fields

        private SupervisorPresenter _presenter;
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

        public string QuestionName
        {
            get { return NameTextBox.Text; }
            set { NameTextBox.Text = value; }
        }

        public string QuestionCategory
        {
            get { return CategoryDropDown.SelectedItem.Value; }
        }

        public object QuestionCategoryDataSource
        {
            get { return CategoryDropDown.DataSource; }
            set { CategoryDropDown.DataSource = value; }
        }

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
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }

        public QuestionComposer QuestionComposer
        {
            get
            {
                if (_questionComposer == null)
                    _questionComposer = LoadControl("~/Controls/QuestionComposer.ascx") as QuestionComposer;
                return _questionComposer;
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
            _presenter.SetQuestionContent();
            if (_questionComposer != null)
                QuestionEditorPlaceHolder.Controls.Add(_questionComposer);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (!Page.IsPostBack)
            {
                CategoryDropDown.DataTextField = "Name";
                CategoryDropDown.DataValueField = "Id";
                CategoryDropDown.DataBind();
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            _presenter.SaveChanges();
        }

        #endregion
    }
}