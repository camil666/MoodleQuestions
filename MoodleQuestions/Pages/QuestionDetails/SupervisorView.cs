﻿using System;
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

        /// <summary>
        /// Gets the name of the question.
        /// </summary>
        /// <value>
        /// The name of the question.
        /// </value>
        public string QuestionName
        {
            get { return _nameTextBox.Text; }
        }

        /// <summary>
        /// Gets the question category id.
        /// </summary>
        /// <value>
        /// The question category id.
        /// </value>
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

        /// <summary>
        /// Gets or sets the question category data source.
        /// </summary>
        /// <value>
        /// The question category data source.
        /// </value>
        public object QuestionCategoryDataSource
        {
            get { return _categoryDropDown.DataSource; }
            set { _categoryDropDown.DataSource = value; }
        }

        /// <summary>
        /// Gets or sets the selected rating.
        /// </summary>
        /// <value>
        /// The selected rating.
        /// </value>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="SupervisorView" /> class.
        /// </summary>
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

        /// <summary>
        /// Raises the <see cref="E:Init" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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

        /// <summary>
        /// Raises the <see cref="E:Load" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var isEditable = QuestionToDisplay.Rating != null;

            if (!Page.IsPostBack)
            {
                _categoryDropDown.DataTextField = "Name";
                _categoryDropDown.DataValueField = "Id";
                Presenter.SetupCategoryDropDown();
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

            if (isEditable)
            {
                _questionComposer = new QuestionComposer()
                {
                    QuestionLabelText = HttpContext.GetGlobalResourceObject("Strings", "QuestionLabelText").ToString(),
                    AnswerLabelText = HttpContext.GetGlobalResourceObject("Strings", "AnswerLabelText").ToString(),
                    FractionLabelText = HttpContext.GetGlobalResourceObject("Strings", "FractionLabelText").ToString(),
                    ValidatorErrorMessage = HttpContext.GetGlobalResourceObject("Strings", "FractionValidatorErrorMessage").ToString(),
                    IsVisibleLabelText = HttpContext.GetGlobalResourceObject("Strings", "IsVisibleLabelText").ToString(),
                    Question = QuestionToDisplay,
                    FractionsValidationGroup = "Fractions"
                };

                QuestionEditorPlaceHolder.Controls.Add(_questionComposer);
            }
            else
            {
                QuestionEditorPlaceHolder.Controls.Add(new QuestionViewer()
                {
                    Question = QuestionToDisplay
                });
            }
        }

        /// <summary>
        /// Handles the Click event of the SaveButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            Presenter.SaveChanges();
            Page.Response.Redirect("~/ManageQuestions.aspx");
        }

        #endregion
    }
}