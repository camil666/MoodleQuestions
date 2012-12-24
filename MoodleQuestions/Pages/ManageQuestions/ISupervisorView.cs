using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoodleQuestions.Pages.ManageQuestions
{
    public interface ISupervisorView : IView
    {
        #region Properties

        object UserDropDownDataSource { get; set; }

        object CategoryDropDownDataSource { get; set; }

        Guid SelectedStudentId { get; }

        int SelectedCategoryId { get; }

        string NewCategoryName { get; }

        #endregion
    }
}
