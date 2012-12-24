using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoodleQuestions.Pages.ManageQuestions
{
    public class SupervisorView : View<SupervisorPresenter>, ISupervisorView
    {
        #region Fields

        private DropDownList _userDropDown;
        private DropDownList _categoryDropDown;
        private TextBox _newCategoryTextBox;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the selected category id.
        /// </summary>
        /// <value>
        /// The selected category id.
        /// </value>
        public int SelectedCategoryId
        {
            get { return int.Parse(_categoryDropDown.SelectedValue); }
        }

        /// <summary>
        /// Gets the name of the new category.
        /// </summary>
        /// <value>
        /// The name of the new category.
        /// </value>
        public string NewCategoryName
        {
            get { return _newCategoryTextBox.Text; }
        }

        /// <summary>
        /// Gets or sets the user drop down data source.
        /// </summary>
        /// <value>
        /// The user drop down data source.
        /// </value>
        public object UserDropDownDataSource
        {
            get { return _userDropDown.DataSource; }
            set { _userDropDown.DataSource = value; }
        }

        /// <summary>
        /// Gets or sets the category drop down data source.
        /// </summary>
        /// <value>
        /// The category drop down data source.
        /// </value>
        public object CategoryDropDownDataSource
        {
            get { return _categoryDropDown.DataSource; }
            set { _categoryDropDown.DataSource = value; }
        }

        /// <summary>
        /// Gets the selected student id.
        /// </summary>
        /// <value>
        /// The selected student id.
        /// </value>
        public Guid SelectedStudentId
        {
            get
            {
                return Guid.Parse(_userDropDown.SelectedItem.Value);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SupervisorView" /> class.
        /// </summary>
        public SupervisorView()
        {
            Presenter = new SupervisorPresenter(this);
            _userDropDown = new DropDownList()
            {
                DataTextField = "FullName",
                DataValueField = "Id"
            };

            _userDropDown.Style.Add(HtmlTextWriterStyle.MarginLeft, "5px");

            _categoryDropDown = new DropDownList()
            {
                DataTextField = "Name",
                DataValueField = "Id"
            };

            _newCategoryTextBox = new TextBox() { ID = "NewCategoryTextBox" };
        }

        #endregion

        #region Methods

        /// <summary>
        /// Raises the <see cref="E:Init" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected override void OnInit(EventArgs e)
        {
            Controls.Add(new Label() { Text = HttpContext.GetGlobalResourceObject("Strings", "UserDropDownLabel").ToString() });
            Controls.Add(_userDropDown);
            base.OnInit(e);
            Controls.Add(new LiteralControl("<br>"));
            Controls.Add(new LiteralControl("<br>"));
            Controls.Add(new Label() { Text = HttpContext.GetGlobalResourceObject("Strings", "CategoryLabelText").ToString() });
            Controls.Add(_categoryDropDown);
            Controls.Add(new LiteralControl("<br>"));
            Controls.Add(new Label() { Text = HttpContext.GetGlobalResourceObject("Strings", "NewCategoryLabelText").ToString() });
            Controls.Add(_newCategoryTextBox);
            Controls.Add(new LiteralControl("<br>"));
            var addCategoryButton = new Button()
            {
                Text = HttpContext.GetGlobalResourceObject("Strings", "AddCategoryLabelText").ToString(),
                ValidationGroup = "CategoryName",
                ID = "DeleteCategoryButton"
            };

            addCategoryButton.Click += AddCategoryButton_Click;
            Controls.Add(addCategoryButton);

            var deleteCategoryButton = new Button()
            {
                Text = HttpContext.GetGlobalResourceObject("Strings", "DeleteCategoryLabelText").ToString(),
                OnClientClick = "if (!ConfirmCategoryDelete()) { return false; };"
            };

            Controls.Add(deleteCategoryButton);
            deleteCategoryButton.Click += DeleteCategoryButton_Click;

            Controls.Add(new RequiredFieldValidator()
            {
                ValidationGroup = "CategoryName",
                ControlToValidate = _newCategoryTextBox.ID,
                ErrorMessage = HttpContext.GetGlobalResourceObject("Strings", "NewCategoryValidationText").ToString()
            });
        }

        /// <summary>
        /// Raises the <see cref="E:Load" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Presenter.SetupUserDropDown();
                Presenter.SetupCategoryDropDown();
                _userDropDown.DataBind();
                _userDropDown.SelectedIndex = 0;
                _categoryDropDown.DataBind();
                _categoryDropDown.SelectedIndex = 0;
                Presenter.SetupGrid();
            }

            base.OnLoad(e);
        }

        private void DeleteCategoryButton_Click(object sender, EventArgs e)
        {
            Presenter.DeleteCategory();
            Presenter.SetupCategoryDropDown();
            _categoryDropDown.DataBind();
            _categoryDropDown.SelectedIndex = 0;
        }

        private void AddCategoryButton_Click(object sender, EventArgs e)
        {
            Presenter.CreateCategory();
            Presenter.SetupCategoryDropDown();
            _categoryDropDown.DataBind();
            _categoryDropDown.SelectedIndex = 0;
        }

        #endregion
    }
}