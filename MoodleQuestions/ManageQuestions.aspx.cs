using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuestionsDAL;

namespace MoodleQuestions
{
    public partial class ManageQuestions : Page
    {
        #region Constants

        #endregion

        #region Fields

        private DropDownList _usersDropDown;

        #endregion

        #region Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (PermissionHelper.UserIsSupervisor)
            {
                _usersDropDown = new DropDownList();
                UserDropDownPlaceHolder.Controls.Add(_usersDropDown);
                //var students = System.Web.Security.Roles.GetUsersInRole("Student");
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
                    
            if (PermissionHelper.UserIsStudent)
            {
                var user = Membership.GetUser();
                if (user == null)
                {
                    return;
                }

                var userId = Guid.Parse(user.ProviderUserKey.ToString());

                using (var context = new Entities())
                {
                    QuestionGridView.DataSource = (from question in context.Questions
                                                   where question.AuthorId == userId
                                                   select question).ToList();
                }
            }
            if (PermissionHelper.UserIsSupervisor)
            {
                using (var context = new Entities())
                {
                    QuestionGridView.DataSource = (from question in context.Questions select question).ToList();
                }

                _usersDropDown.DataSource = PermissionHelper.GetStudents();
                _usersDropDown.DataBind();
            }

            QuestionGridView.DataBind();
        }

        #endregion
    }
}