using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MoodleQuestions.Pages.Reports
{
    public class StudentView : BaseView
    {
        #region Properties

        public override Guid SelectedStudentId
        {
            get
            {
                return Guid.Parse(Membership.GetUser().ProviderUserKey.ToString());
            }
        }

        #endregion
    }
}