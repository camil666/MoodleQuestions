namespace MoodleQuestions.Pages.CreateQuestion
{
    public class AnonymousUserView : BaseView
    {
        #region Constructors

        public AnonymousUserView()
        {
            QuestionComposerControl.AnonymousMode = true;
        }

        #endregion
    }
}