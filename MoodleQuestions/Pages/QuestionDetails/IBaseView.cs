using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using MoodleQuestions.Controls;
using QuestionsDAL;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public interface IBaseView
    {
        #region Properties

        int QuestionId { get; }

        Question QuestionToDisplay { get; set; }

        #endregion
    }
}
