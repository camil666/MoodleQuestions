using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using QuestionsDAL;

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
            _view.QuestionCategoryDataSource = Model.GetQuestionCategories();

            if (Question.QuestionType != null)
            {
                _view.QuestionType = Question.QuestionType.Name;
            }
            else
            {
                _view.QuestionType = Constants.EmptyText;
            }
        }
        //TODO: dokonczyc
        public void SaveChanges()
        {
            var newQuestion = new Question()
            {
                CategoryId = int.Parse(_view.QuestionCategory),
                Name = _view.QuestionName,
                Rating = _view.SelectedRating,
                //Content = _view.
            };

            Model.SaveChanges(Question, newQuestion);
        }
        #endregion
    }
}