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
            Model = new SupervisorModel();
        }

        #endregion

        #region Methods

        public void SetupCategoryDropDown()
        {
            var questionCategories = (Model as SupervisorModel).GetQuestionCategories().ToList();

            CategoryHelper.ConcatCategoryName(questionCategories);

            questionCategories.Insert(0, new QuestionCategory() { Id = 0, Name = "-" });
            _view.QuestionCategoryDataSource = questionCategories;
        }

        public void SaveChanges()
        {
            var newQuestion = new Question()
            {
                Id = _view.QuestionId,
                Name = _view.QuestionName,
                Rating = _view.SelectedRating,
                CategoryId = _view.QuestionCategoryId
            };

            Model.SaveChanges(newQuestion);
        }

        #endregion
    }
}