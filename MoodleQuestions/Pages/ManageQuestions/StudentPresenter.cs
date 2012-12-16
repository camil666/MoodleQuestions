﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MoodleQuestions.Pages.ManageQuestions
{
    public class StudentPresenter : BasePresenter
    {
        #region Constructors

        public StudentPresenter(IStudentView view)
            : base(view)
        {
        }

        #endregion

        #region Methods

        public override void SetupGrid()
        {
            var user = Membership.GetUser();
            if (user != null)
            {
                var userId = Guid.Parse(user.ProviderUserKey.ToString());
                View.QuestionGridDataSource = Model.GetUserQuestions(userId);
            }
        }

        #endregion
    }
}