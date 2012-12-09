﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public interface ISupervisorView : IBaseView
    {
        #region Properties

        string QuestionCategory { get; }

        object QuestionCategoryDataSource { get; set; }

        int? SelectedRating { get; set; }

        #endregion
    }
}
