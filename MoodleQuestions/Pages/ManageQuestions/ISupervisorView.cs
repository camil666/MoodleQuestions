using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoodleQuestions.Pages.ManageQuestions
{
    public interface ISupervisorView : IBaseView
    {
        #region Properties

        object UserDropDownDataSource { get; set; }

        Guid SelectedStudentId { get; }

        #endregion
    }
}
