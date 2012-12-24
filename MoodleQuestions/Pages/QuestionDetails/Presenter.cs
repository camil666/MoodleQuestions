using System;
using System.Web.Security;
using MoodleQuestions.Generics;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public abstract class Presenter<TView, TModel> : GenericPresenter<TView, TModel>, IPresenter
        where TView : IView
        where TModel : Model, new()
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Presenter{TView,TModel}" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        protected Presenter(TView view)
            : base(view)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the question.
        /// </summary>
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