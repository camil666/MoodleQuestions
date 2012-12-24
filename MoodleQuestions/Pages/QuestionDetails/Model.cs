using System.Linq;
using MoodleQuestions.Repositories;
using QuestionsDAL;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public abstract class Model
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Model" /> class.
        /// </summary>
        protected Model()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the question.
        /// </summary>
        /// <param name="questionId">The question id.</param>
        /// <returns>Found question.</returns>
        public Question GetQuestion(int questionId)
        {
            return QuestionRepository.Find(question => question.Id == questionId && question.IsDeleted == false).SingleOrDefault();
        }

        /// <summary>
        /// Deletes the question.
        /// </summary>
        /// <param name="id">The id.</param>
        public void DeleteQuestion(int id)
        {
            QuestionRepository.MarkAsDeleted(id);
        }

        #endregion
    }
}