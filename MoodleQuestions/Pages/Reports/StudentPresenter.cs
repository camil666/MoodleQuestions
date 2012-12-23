using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodleQuestions.Pages.Reports
{
    public class StudentPresenter : Presenter<IStudentView, Model>
    {
        #region Constructors

        public StudentPresenter(IStudentView view)
            : base(view)
        {
        }

        #endregion
    }
}