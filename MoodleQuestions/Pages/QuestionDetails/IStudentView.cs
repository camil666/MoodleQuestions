using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuestionsDAL;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public interface IStudentView : IBaseView
    {
        #region Properties

        Question ChangedQuestion { get; }

        bool QuestionIsVisible { get; }

        //string QuestionRating { get; set; }

        //bool IsEditable { get; set; }

        #endregion
    }
}
