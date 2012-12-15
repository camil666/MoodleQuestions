using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoodleQuestions.Pages.Raports
{
    public interface ISupervisorView : IBaseView
    {
        #region Properties

        object DropDownDataSource { get; set; }

        #endregion
    }
}
