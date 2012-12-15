using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodleQuestions.Pages.ManageQuestions
{
    public class SupervisorPresenter : BasePresenter
    {
        //#region Fields

        //private ISupervisorView _view;

        //#endregion

        #region Constructors

        public SupervisorPresenter(ISupervisorView view)
            : base(view)
        {
            //_view = view;
        }

        #endregion

        #region Methods

        public void SetupUserDropDown()
        {
            (View as ISupervisorView).UserDropDownDataSource = Model.GetUsers();
        }
        //TODO: zrobic finda z kilkoma filtrami (do przemyslenia)?
        public override void SetupGrid()
        {
            var userid = (View as ISupervisorView).SelectedStudentId;
            View.QuestionGridDataSource = Model.GetUserQuestions(userid);
        }

        #endregion
    }
}