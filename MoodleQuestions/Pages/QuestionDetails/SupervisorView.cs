using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoodleQuestions.Controls;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public class SupervisorView : View<SupervisorPresenter>, ISupervisorView
    {
        #region Fields

        private DropDownList _categoryDropDown;
        private DropDownList _ratingDropDown;
        private TextBox _nameTextBox;

        #endregion

        #region Properties

        public string QuestionName
        {
            get { return _nameTextBox.Text; }
        }

        public int? QuestionCategoryId
        {
            get
            {
                int result;
                if (int.TryParse(_categoryDropDown.SelectedItem.Value, out result) == true)
                {
                    if (result != 0)
                    {
                        return result;
                    }

                    return null;
                }
                else
                {
                    return null;
                }
            }
        }

        public object QuestionCategoryDataSource
        {
            get { return _categoryDropDown.DataSource; }
            set { _categoryDropDown.DataSource = value; }
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
            _categoryDropDown = new DropDownList();
            Presenter = new SupervisorPresenter(this);
            _ratingDropDown = new DropDownList();
            _nameTextBox = new TextBox();
            SaveButton.Click += SaveButton_Click;
        }

        #endregion

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            var categoryRow = new TableRow();
            categoryRow.Cells.Add(new TableCell() { Text = HttpContext.GetGlobalResourceObject("Strings", "CategoryLabelText").ToString() });
            var categoryCell = new TableCell();
            categoryRow.Cells.Add(categoryCell);
            categoryCell.Controls.Add(_categoryDropDown);
            DetailsTable.Rows.Add(categoryRow);
            _ratingCell.Controls.Add(_ratingDropDown);
            _nameCell.Controls.Add(_nameTextBox);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!Page.IsPostBack)
            {
                _categoryDropDown.DataTextField = "Name";
                _categoryDropDown.DataValueField = "Id";
                (Presenter as SupervisorPresenter).SetupCategoryDropDown();
                _categoryDropDown.DataBind();
                _ratingDropDown.DataSource = new string[] { "-", "2", "3", "4", "5" };
                _ratingDropDown.DataBind();

                if (!string.IsNullOrEmpty(QuestionToDisplay.Name))
                {
                    _nameTextBox.Text = QuestionToDisplay.Name;
                }

                if (QuestionToDisplay.Rating != null)
                {
                    SelectedRating = QuestionToDisplay.Rating.Value;
                }

                if (QuestionToDisplay.CategoryId != null)
                {
                    _categoryDropDown.Items.FindByValue(QuestionToDisplay.CategoryId.ToString()).Selected = true;
                }
            }

            QuestionEditorPlaceHolder.Controls.Add(new QuestionViewer()
            {
                Question = QuestionToDisplay
            });
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            (Presenter as SupervisorPresenter).SaveChanges();
            Page.Response.Redirect("~/ManageQuestions.aspx");
        }

        #endregion
    }
}