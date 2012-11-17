using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public interface IStudentView : IBaseView
    {
        #region Properties

        string QuestionRating { get; set; }

        #endregion
    }
}
