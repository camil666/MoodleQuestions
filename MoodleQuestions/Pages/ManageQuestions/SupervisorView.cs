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

        private SupervisorPresenter _presenter;
        private DropDownList _userDropDown;

        #endregion

        #region Properties

        public object UserDropDownDataSource
        {
            get { return _userDropDown.DataSource; }
            set { _userDropDown.DataSource = value; }
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
            _presenter = new SupervisorPresenter(this);
            _userDropDown = new DropDownList()
            {
                DataTextField = "FullName",
                DataValueField = "Id"
            };
        }

        #endregion

        #region Methods
        //TODO: dodac inicjalizacja grida z markupu
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
                _presenter.SetupUserDropDown();
                _userDropDown.DataBind();
                _userDropDown.SelectedIndex = 0;
                _presenter.SetupGrid();
            }

            base.OnLoad(e);
        }

        #endregion
    }
}