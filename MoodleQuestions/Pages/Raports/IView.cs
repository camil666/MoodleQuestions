﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoodleQuestions.Pages.Raports
{
    public interface IView
    {
        #region Properties

        object DropDownDataSource { get; set; }

        Guid SelectedStudentId { get; }

        DateTime? StartDate { get; }

        DateTime? EndDate { get; }

        string QuestionCount { set; }

        string RatedQuestionCount { set; }

        string UnratedQuestionCount { set; }

        string AverageRating { set; }

        #endregion
    }
}
