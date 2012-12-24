namespace MoodleQuestions.Pages.QuestionDetails
{
    public interface IStudentView : IView
    {
        #region Properties

        /// <summary>
        /// Gets a value indicating whether question is visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if question is visible; otherwise, <c>false</c>.
        /// </value>
        bool QuestionIsVisible { get; }

        #endregion
    }
}
