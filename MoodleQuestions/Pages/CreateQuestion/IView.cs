using QuestionsDAL;

namespace MoodleQuestions.Pages.CreateQuestion
{
    public interface IView
    {
        #region Properties

        /// <summary>
        /// Gets the question.
        /// </summary>
        /// <returns>Created question.</returns>
        Question GetQuestion();

        #endregion
    }
}
