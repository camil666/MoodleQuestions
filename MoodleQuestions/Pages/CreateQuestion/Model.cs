using MoodleQuestions.Repositories;
using QuestionsDAL;

namespace MoodleQuestions.Pages.CreateQuestion
{
    public class Model
    {
        #region Methods

        /// <summary>
        /// Saves the question.
        /// </summary>
        /// <param name="question">The question.</param>
        public void SaveQuestion(Question question)
        {
            QuestionRepository.Add(question);
        }

        #endregion
    }
}