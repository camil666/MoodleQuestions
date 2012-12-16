using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using MoodleQuestions.Controls;
using QuestionsDAL;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public class BasePresenter
    {
        #region Fields

        private IBaseView _view;

        #endregion

        #region Properties

        protected BaseModel Model { get; set; }

        #endregion

        #region Constructors

        public BasePresenter(IBaseView view)
        {
            _view = view;
        }

        #endregion

        #region Methods

        public void SetQuestion()
        {
            var loggedUserId = (Guid)Membership.GetUser().ProviderUserKey;
            var question = Model.GetQuestion(_view.QuestionId);
            if (loggedUserId == question.AuthorId || PermissionHelper.UserIsSupervisor)
            {
                _view.QuestionToDisplay = question;
            }
            else
            {
                _view.QuestionToDisplay = null;
            }
        }

        #endregion
    }
}