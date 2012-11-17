using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public class SupervisorPresenter : BasePresenter
    {
        #region Fields

        private ISupervisorView _view;

        #endregion

        #region Constructors

        public SupervisorPresenter(ISupervisorView view)
            : base(view)
        {
            _view = view;
            Model = new Model();
        }

        #endregion

        #region Methods

        public override void SetQuestionDetails()
        {
            base.SetQuestionDetails();

            _view.QuestionName = Question.Name;

            if (Question.QuestionCategory != null)
                _view.QuestionCategory = Question.QuestionCategory.Name;
            else
                _view.QuestionCategory = Constants.EmptyText;

            if (Question.QuestionType != null)
                _view.QuestionType = Question.QuestionType.Name;
            else
                _view.QuestionType = Constants.EmptyText;
        }

        #endregion
    }
}