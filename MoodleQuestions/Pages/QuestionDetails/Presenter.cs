using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using MoodleQuestions.Controls;
using MoodleQuestions.Generics;
using QuestionsDAL;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public abstract class Presenter<TView, TModel> : GenericPresenter<TView, TModel>, IPresenter
        where TView : IView
        where TModel : Model, new()
    {
        #region Constructors

        public Presenter(TView view)
            : base(view)
        {
        }

        #endregion

        #region Methods

        public void SetQuestion()
        {
            var loggedUserId = (Guid)Membership.GetUser().ProviderUserKey;
            var question = Model.GetQuestion(View.QuestionId);
            if (loggedUserId == question.AuthorId || PermissionHelper.UserIsSupervisor)
            {
                View.QuestionToDisplay = question;
            }
            else
            {
                View.QuestionToDisplay = null;
            }
        }

        #endregion
    }
}