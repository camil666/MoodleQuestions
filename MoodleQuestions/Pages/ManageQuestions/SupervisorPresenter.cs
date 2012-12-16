using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodleQuestions.Pages.ManageQuestions
{
    public class SupervisorPresenter : BasePresenter
    {
        #region Constructors

        public SupervisorPresenter(ISupervisorView view)
            : base(view)
        {
        }

        #endregion

        #region Methods

        public void SetupUserDropDown()
        {
            (View as ISupervisorView).UserDropDownDataSource = Model.GetUsers();
        }

        public override void SetupGrid()
        {
            var userid = (View as ISupervisorView).SelectedStudentId;
            View.QuestionGridDataSource = Model.GetUserQuestions(userid);
        }

        #endregion
    }
}