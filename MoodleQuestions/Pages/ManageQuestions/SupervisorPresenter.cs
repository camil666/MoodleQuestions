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

        public void SetupCategoryDropDown()
        {
            var questionCategories = Model.GetQuestionCategories().ToList();

            CategoryHelper.ConcatCategoryName(questionCategories);

            questionCategories.Insert(0, new QuestionCategory() { Id = 0, Name = "-" });
            View.CategoryDropDownDataSource = questionCategories;
        }

        public void SetupGrid()
        {
            var userid = View.SelectedStudentId;
            View.QuestionGridDataSource = Model.GetUserQuestions(userid);
        }

        #endregion
    }
}