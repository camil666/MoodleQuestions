namespace MoodleQuestions.Pages.CreateQuestion
{
    public class AnonymousUserView : View
    {
        #region Constructors

        public AnonymousUserView()
        {
            QuestionComposerControl.AnonymousMode = true;
        }

        #endregion
    }
}