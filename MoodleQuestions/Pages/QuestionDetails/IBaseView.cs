using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public interface IBaseView
    {
        #region Properties

        int QuestionId { get; }
        string QuestionCreationDate { get; set; }
        string QuestionAuthor { get; set; }

        #endregion
    }
}
