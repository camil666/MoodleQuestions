﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using QuestionsDAL;

namespace MoodleQuestions.Pages.CreateQuestion
{
    public class LoggedUserView : BaseView, IView
    {
        #region Fields

        private LoggedUserPresenter _presenter;
        private Button _saveButton;

        #endregion

        #region Constructors

        public LoggedUserView()
        {
            _presenter = new LoggedUserPresenter(this);
            _saveButton = new Button()
            {
                Text = HttpContext.GetGlobalResourceObject("Strings", "SaveButtonText").ToString()
            };

            _saveButton.Click += SaveButton_Click;
        }

        #endregion

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Controls.Add(_saveButton);
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            _presenter.SaveQuestion();
        }

        #endregion
    }
}