namespace MoodleQuestions.Pages.CreateQuestion
{
    public class AnonymousUserView : View
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AnonymousUserView" /> class.
        /// </summary>
        public AnonymousUserView()
        {
            QuestionComposerControl.AnonymousMode = true;
        }

        #endregion
    }
}