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

        #endregion

        #region Constructors

        public SupervisorView()
        {
            _presenter = new SupervisorPresenter(this);
            _userDropDown = new DropDownList();
        }

        #endregion

        #region Methods
        //TODO: dodac inicjalizacja grida z markupu
        protected override void OnInit(EventArgs e)
        {
            Controls.Add(_userDropDown);
            base.OnInit(e);
            
            //var students = System.Web.Security.Roles.GetUsersInRole("Student");
        }

        protected override void OnPreRender(EventArgs e)
        {
            _presenter.SetupUserDropDown();
            _presenter.SetupGrid();
            _userDropDown.DataBind();

            base.OnPreRender(e);
        }

        #endregion
    }
}