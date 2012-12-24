using System.Linq;
using QuestionsDAL;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public class SupervisorPresenter : Presenter<ISupervisorView, SupervisorModel>
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
        /// Setups the category drop down.
        /// </summary>
        public void SetupCategoryDropDown()
        {
            var questionCategories = Model.GetQuestionCategories().ToList();

            CategoryHelper.MakeFullCategoryNames(questionCategories);

            var orderedQuestionCategories = questionCategories.OrderBy(item => item.Name).ToList();
            orderedQuestionCategories.Insert(0, new QuestionCategory() { Id = 0, Name = "-" });
            View.QuestionCategoryDataSource = orderedQuestionCategories;
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
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