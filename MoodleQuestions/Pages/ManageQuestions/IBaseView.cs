using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoodleQuestions.Pages.ManageQuestions
{
    public interface IBaseView
    {
        #region Properties

        object QuestionGridDataSource { get; set; }

        #endregion
    }
}
