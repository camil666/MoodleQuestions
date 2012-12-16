using QuestionsDAL;

namespace MoodleQuestions.Pages.CreateQuestion
{
    public interface IView
    {
        #region Properties

        Question GetQuestion();

        #endregion
    }
}
