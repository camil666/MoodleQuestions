using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoodleQuestions.Pages.ManageQuestions
{
    public interface IView
    {
        #region Properties

        object QuestionGridDataSource { get; set; }

        IEnumerable<int> QuestionIds { get; }

        #endregion
    }
}
