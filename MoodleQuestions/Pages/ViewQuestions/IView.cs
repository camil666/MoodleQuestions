using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuestionsDAL;

namespace MoodleQuestions.Pages.ViewQuestions
{
    public interface IView
    {
        #region Properties

        object QuestionRepeaterDataSource { get; set; }

        object CategoryDataSource { get; set; }

        int SelectedCategoryId { get; }

        DateTime? StartDate { get; }

        DateTime? EndDate { get; }

        #endregion

        #region Methods

        IEnumerable<int> GetQuestionIds();

        #endregion
    }
}
