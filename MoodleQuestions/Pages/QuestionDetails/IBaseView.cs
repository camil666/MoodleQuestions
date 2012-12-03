using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using MoodleQuestions.Controls;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public interface IBaseView
    {
        #region Properties

        int QuestionId { get; }
        string QuestionCreationDate { get; set; }
        string QuestionAuthor { get; set; }
        QuestionComposer QuestionComposer { get; }

        #endregion
    }
}
