using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuestionsDAL;

namespace MoodleQuestions.Pages.ManageQuestions
{
    public class SupervisorPresenter : Presenter<ISupervisorView, Model>
    {
        #region Constructors

        public SupervisorPresenter(ISupervisorView view)
            : base(view)
        {
        }

        #endregion

        #region Methods

        public void SetupUserDropDown()
        {
            View.UserDropDownDataSource = Model.GetUsers();
        }

        public void DeleteCategory()
        {
            Model.DeleteCategory(View.SelectedCategoryId);
        }

        public void CreateCategory()
        {
            if (View.SelectedCategoryId != 0)
            {
                Model.CreateCategory(View.NewCategoryName, View.SelectedCategoryId);
            }
            else
            {
                Model.CreateCategory(View.NewCategoryName, null);
            }
        }

        public void SetupCategoryDropDown()
        {
            var questionCategories = Model.GetQuestionCategories();

            CategoryHelper.ConcatCategoryName(questionCategories);
            var orderedQuestionCategories = questionCategories.OrderBy(item => item.Name).ToList();
            orderedQuestionCategories.Insert(0, new QuestionCategory() { Id = 0, Name = "/" });
            View.CategoryDropDownDataSource = orderedQuestionCategories;
        }

        public void SetupGrid()
        {
            var userid = View.SelectedStudentId;
            View.QuestionGridDataSource = Model.GetUserQuestions(userid);
        }

        #endregion
    }
}