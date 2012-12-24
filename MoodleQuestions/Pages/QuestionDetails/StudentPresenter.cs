namespace MoodleQuestions.Pages.QuestionDetails
{
    public class StudentPresenter : Presenter<IStudentView, StudentModel>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public StudentPresenter(IStudentView view)
            : base(view)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Saves the changes.
        /// </summary>
        public void SaveChanges()
        {
            var newQuestion = View.ChangedQuestion;
            if (newQuestion != null)
            {
                newQuestion.Id = View.QuestionId;
            }
            else
            {
                newQuestion = Model.GetQuestion(View.QuestionId);
                newQuestion.IsVisible = View.QuestionIsVisible;
            }

            Model.SaveChanges(newQuestion);
        }

        /// <summary>
        /// Deletes the question.
        /// </summary>
        /// <param name="id">The id.</param>
        public void DeleteQuestion(int id)
        {
            Model.DeleteQuestion(id);
        }

        #endregion
    }
}