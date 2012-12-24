using QuestionsDAL;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public interface IView
    {
        #region Properties

        /// <summary>
        /// Gets the question id.
        /// </summary>
        /// <value>
        /// The question id.
        /// </value>
        int QuestionId { get; }

        /// <summary>
        /// Gets the changed question.
        /// </summary>
        /// <value>
        /// The changed question.
        /// </value>
        Question ChangedQuestion { get; }

        /// <summary>
        /// Gets or sets the question to display.
        /// </summary>
        /// <value>
        /// The question to display.
        /// </value>
        Question QuestionToDisplay { get; set; }

        #endregion
    }
}
