using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using QuestionsDAL;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public class SupervisorPresenter : Presenter<ISupervisorView, SupervisorModel>
    {
        #region Constructors

        public SupervisorPresenter(ISupervisorView view)
            : base(view)
        {
        }

        #endregion

        #region Methods

        public void SetupCategoryDropDown()
        {
            var questionCategories = Model.GetQuestionCategories().ToList();

            CategoryHelper.ConcatCategoryName(questionCategories);

            var orderedQuestionCategories = questionCategories.OrderBy(item => item.Name).ToList();
            orderedQuestionCategories.Insert(0, new QuestionCategory() { Id = 0, Name = "-" });
            View.QuestionCategoryDataSource = orderedQuestionCategories;
        }

        public void SaveChanges()
        {
            var newQuestion = View.ChangedQuestion;
            if (newQuestion == null)
            {
                newQuestion = Model.GetQuestion(View.QuestionId);
            }

            newQuestion.Id = View.QuestionId;
            newQuestion.Name = View.QuestionName;
            newQuestion.Rating = View.SelectedRating;
            newQuestion.CategoryId = View.QuestionCategoryId;

            Model.SaveChanges(newQuestion);
        }

        #endregion
    }
}