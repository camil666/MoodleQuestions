using System.Linq;
using QuestionsDAL;

namespace MoodleQuestions.Pages.ManageQuestions
{
    public class SupervisorPresenter : Presenter<ISupervisorView, Model>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SupervisorPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public SupervisorPresenter(ISupervisorView view)
            : base(view)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets up the user drop down.
        /// </summary>
        public void SetupUserDropDown()
        {
            View.UserDropDownDataSource = PermissionHelper.GetStudents();
        }

        /// <summary>
        /// Deletes the category.
        /// </summary>
        public void DeleteCategory()
        {
            Model.DeleteCategory(View.SelectedCategoryId);
        }

        /// <summary>
        /// Creates the category.
        /// </summary>
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

        /// <summary>
        /// Sets up the category drop down.
        /// </summary>
        public void SetupCategoryDropDown()
        {
            var questionCategories = Model.GetQuestionCategories();

            CategoryHelper.MakeFullCategoryNames(questionCategories);
            var orderedQuestionCategories = questionCategories.OrderBy(item => item.Name).ToList();
            orderedQuestionCategories.Insert(0, new QuestionCategory() { Id = 0, Name = "/" });
            View.CategoryDropDownDataSource = orderedQuestionCategories;
        }

        /// <summary>
        /// Sets up the grid.
        /// </summary>
        public void SetupGrid()
        {
            var userid = View.SelectedStudentId;
            View.QuestionGridDataSource = Model.GetUserQuestions(userid);
        }

        #endregion
    }
}