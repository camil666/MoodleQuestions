using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoodleQuestions.Pages.ManageQuestions
{
    public class SupervisorView : BaseView, ISupervisorView
    {
        #region Fields

        private DropDownList _userDropDown;
        private DropDownList _categoryDropDown;

        #endregion

        #region Properties

        public object UserDropDownDataSource
        {
            get { return _userDropDown.DataSource; }
            set { _userDropDown.DataSource = value; }
        }
        //TODO: dokonczyc zarzadzanie kategoriami
        public object CategoryDropDownDataSource
        {
            get { return _categoryDropDown.DataSource; }
            set { _categoryDropDown.DataSource = value; }
        }

        public Guid SelectedStudentId
        {
            get
            {
                return Guid.Parse(_userDropDown.SelectedItem.Value);
            }
        }

        #endregion

        #region Constructors

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
        }

        #endregion

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            Controls.Add(new Label() { Text = HttpContext.GetGlobalResourceObject("Strings", "UserDropDownLabel").ToString() });
            Controls.Add(_userDropDown);
            base.OnInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                (Presenter as SupervisorPresenter).SetupUserDropDown();
                _userDropDown.DataBind();
                _userDropDown.SelectedIndex = 0;
                Presenter.SetupGrid();
            }

            base.OnLoad(e);
        }

        #endregion
    }
}