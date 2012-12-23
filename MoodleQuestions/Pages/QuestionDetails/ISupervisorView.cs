using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public interface ISupervisorView : IView
    {
        #region Properties

        string QuestionName { get; }

        int? QuestionCategoryId { get; }

        object QuestionCategoryDataSource { get; set; }

        int? SelectedRating { get; }

        #endregion
    }
}
