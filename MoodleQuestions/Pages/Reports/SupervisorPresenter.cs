using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodleQuestions.Pages.Reports
{
    public class SupervisorPresenter : Presenter<ISupervisorView, Model>
    {
        #region Constructors

        public SupervisorPresenter(ISupervisorView view)
            : base(view)
        {
        }

        #endregion

        #region Methods

        public void SetupDropDown()
        {
            View.DropDownDataSource = Model.GetStudents();
        }

        #endregion
    }
}