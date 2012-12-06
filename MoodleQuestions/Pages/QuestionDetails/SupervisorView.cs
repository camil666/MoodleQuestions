using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using MoodleQuestions.Controls;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public class SupervisorView : BaseView, ISupervisorView
    {
        #region Fields

        private DropDownList _categoryDropDown { get; set; }

        private DropDownList _ratingDropDown { get; set; }

        private TextBox _nameTextBox { get; set; }

        #endregion

        #region Properties

        public override string QuestionName
        {
            get { return _nameTextBox.Text; }
            set { _nameTextBox.Text = value; }
        }

        public string QuestionCategory
        {
            get { return _categoryDropDown.SelectedItem.Value; }
        }

        public object QuestionCategoryDataSource
        {
            get { return _categoryDropDown.DataSource; }
            set { _categoryDropDown.DataSource = value; }
        }

        public object QuestionRatingDataSource
        {
            get { return _ratingDropDown.DataSource; }
            set { _ratingDropDown.DataSource = value; }
        }

        public int? SelectedRating
        {
            get
            {
                int result;
                if (int.TryParse(_ratingDropDown.SelectedItem.Text, out result) == true)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }

            set
            {
                _ratingDropDown.Items.FindByText(value.ToString()).Selected = true;
            }
        }

        #endregion

        #region Constructors

        public SupervisorView()
        {
            Presenter = new SupervisorPresenter(this);
        }

        #endregion

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            SaveButton.Click += SaveButton_Click;

            _categoryDropDown = new DropDownList();
            var categoryRow = new TableRow();
            categoryRow.Cells.Add(new TableCell() { Text = HttpContext.GetGlobalResourceObject("Strings", "CategoryLabelText").ToString() });
            var categoryCell = new TableCell();
            categoryRow.Cells.Add(categoryCell);
            categoryCell.Controls.Add(_categoryDropDown);
            DetailsTable.Rows.Add(categoryRow);

            _ratingDropDown = new DropDownList();
            _ratingCell.Controls.Add(_ratingDropDown);

            _nameTextBox = new TextBox();
            _nameCell.Controls.Add(_nameTextBox);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (!Page.IsPostBack)
            {
                _categoryDropDown.DataTextField = "Name";
                _categoryDropDown.DataValueField = "Id";
                _categoryDropDown.DataBind();
                _ratingDropDown.DataBind();
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            (Presenter as SupervisorPresenter).SaveChanges();
        }

        #endregion
    }
}