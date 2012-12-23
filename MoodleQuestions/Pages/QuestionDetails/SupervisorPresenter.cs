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

            questionCategories.Insert(0, new QuestionCategory() { Id = 0, Name = "-" });
            View.QuestionCategoryDataSource = questionCategories;
        }

        public void SaveChanges()
        {
            var newQuestion = new Question()
            {
                Id = View.QuestionId,
                Name = View.QuestionName,
                Rating = View.SelectedRating,
                CategoryId = View.QuestionCategoryId
            };

            Model.SaveChanges(newQuestion);
        }

        #endregion
    }
}