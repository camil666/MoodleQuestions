using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoodleQuestions.Account
{
    public partial class Manage : Page
    {
        protected static string ConvertToDisplayDateTime(DateTime? utcDateTime)
        {
            // You can change this method to convert the UTC date time into the desired display
            // offset and format. Here we're converting it to the server timezone and formatting
            // as a short date and a long time string, using the current thread culture.
            return utcDateTime.HasValue ? utcDateTime.Value.ToLocalTime().ToString("G") : "[never]";
        }

        protected string SuccessMessage
        {
            get;
            private set;
        }

        protected bool CanRemoveExternalLogins
        {
            get;
            private set;
        }

        protected void Page_Load()
        {
            if (!IsPostBack)
            {
                // Render success message
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Account/Manage.aspx");

                    SuccessMessage =
                        message == "ChangePwdSuccess" ? "Your password has been changed."
                        : string.Empty;
                    successMessage.Visible = !string.IsNullOrEmpty(SuccessMessage);
                }
            }
        }

        protected void setPassword_Click(object sender, EventArgs e)
        {
        }

        protected T Item<T>() where T : class
        {
            return GetDataItem() as T ?? default(T);
        }
    }
}