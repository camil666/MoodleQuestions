using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoodleQuestions.Pages.ManageQuestions
{
    public class StudentView : BaseView, IStudentView
    {
        #region Fields

        protected StudentPresenter _presenter { get; set; }

        #endregion

        #region Constructors

        public StudentView()
        {
            _presenter = new StudentPresenter(this);
        }

        #endregion

        #region Methods

        //protected override void OnInit(EventArgs e)
        //{
        //    base.OnInit(e);
        //    //var students = System.Web.Security.Roles.GetUsersInRole("Student");
        //}

        protected override void OnPreRender(EventArgs e)
        {
            //var user = Membership.GetUser();
            //if (user != null)
            //{
            //    var userId = Guid.Parse(user.ProviderUserKey.ToString());

            //}

            _presenter.SetupGrid();

            base.OnPreRender(e);
        }

        #endregion
    }
}