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

            _view.QuestionCategoryDataSource = Model.GetQuestionCategories();
            _view.QuestionRatingDataSource = new string[] { "-", "2", "3", "4", "5" };

            if (Question.QuestionType != null)
            {
                _view.QuestionType = Question.QuestionType.Name;
            }
            else
            {
                _view.QuestionType = string.Empty;
            }

            if (Question.Rating != null)
            {
                _view.SelectedRating = Question.Rating.Value;
            }
        }
        //TODO: dokonczyc
        public void SaveChanges()
        {
            var newQuestion = _view.QuestionComposer.Question;
            newQuestion.Name = _view.QuestionName;
            newQuestion.CategoryId = int.Parse(_view.QuestionCategory);
            newQuestion.Rating = _view.SelectedRating;
            //var newQuestion = new Q_view.QuestionNameuestion()
            //{
            //    CategoryId = int.Parse(_view.QuestionCategory),
            //    Name = _view.QuestionName,
            //    Rating = _view.SelectedRating,
            //    Content = _view.QuestioncC
            //};

            Model.SaveChanges(Question, newQuestion);
        }
        #endregion
    }
}