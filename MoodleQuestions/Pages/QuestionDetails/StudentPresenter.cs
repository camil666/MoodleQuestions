using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuestionsDAL;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public class StudentPresenter : BasePresenter
    {
        #region Fields

        private IStudentView _view;

        #endregion

        #region Constructors

        public StudentPresenter(IStudentView view)
            :base(view)
        {
            _view = view;
            Model = new Model();
        }

        #endregion

        #region Methods

        public override void SetQuestionDetails()
        {
            base.SetQuestionDetails();

            if (Question.Rating != null)
                _view.QuestionRating = Question.Rating.Value.ToString();
        }

        #endregion
    }
}