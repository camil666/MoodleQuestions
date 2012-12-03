using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuestionsDAL;

namespace MoodleQuestions.Pages.CreateQuestion
{
    public interface IView
    {
        #region Properties

        Question GetQuestion();

        #endregion
    }
}
