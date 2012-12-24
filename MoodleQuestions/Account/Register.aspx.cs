using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuestionsDAL;

namespace MoodleQuestions.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);

            var firstNameTextBox = RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("FirstName") as TextBox;
            var lastNameTextBox = RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("LastName") as TextBox;
            var userNameTextBox = RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("UserName") as TextBox;

            var userName = userNameTextBox.Text;

            System.Web.Security.Roles.AddUserToRole(userName, "Student");

            using (var context = new Entities())
            {
                var user = (from item in context.Users
                            where item.UserName == userName
                            select item).FirstOrDefault();

                user.FirstName = firstNameTextBox.Text;
                user.LastName = lastNameTextBox.Text;

                context.SaveChanges();
            }

            Response.Redirect("~/");
        }
    }
}