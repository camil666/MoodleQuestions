using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoodleQuestions.Pages.ViewQuestions
{
    public interface IView
    {
        object QuestionRepeaterDataSource { get; set; }
    }
}
