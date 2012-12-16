using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodleQuestions.Pages.Reports
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

        public void SetupDropDown()
        {
            (View as ISupervisorView).DropDownDataSource = Model.GetStudents();
        }

        #endregion
    }
}