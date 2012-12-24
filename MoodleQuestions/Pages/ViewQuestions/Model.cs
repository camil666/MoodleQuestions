using System;
using System.Collections.Generic;
using System.Linq;
using MoodleQuestions.Repositories;
using QuestionsDAL;

namespace MoodleQuestions.Pages.ViewQuestions
{
    public class Model
    {
        #region Methods

        /// <summary>
        /// Gets the question categories.
        /// </summary>
        /// <returns>Questions categories.</returns>
        public IEnumerable<QuestionCategory> GetQuestionCategories()
        {
            return QuestionCategoryRepository.GetAll();
        }

        /// <summary>
        /// Gets the viewable questions.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>Viewable questions.</returns>
        public IEnumerable<Question> GetViewableQuestions(DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null || endDate == null)
            {
                return QuestionRepository.Find(item => item.IsVisible == true && item.IsDeleted == false);
            }
            else
            {
                return QuestionRepository.Find(item => item.CreationDate >= startDate && item.CreationDate <= endDate && item.IsDeleted == false && item.IsVisible == true);
            }
        }

        /// <summary>
        /// Gets the viewable questions.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="categoryId">The category id.</param>
        /// <returns>Viewable questions.</returns>
        public IEnumerable<Question> GetViewableQuestions(DateTime? startDate, DateTime? endDate, int? categoryId)
        {
            if (startDate == null || endDate == null)
            {
                return QuestionRepository.Find(item => item.IsVisible == true && item.IsDeleted == false && item.CategoryId == categoryId);
            }
            else
            {
                return QuestionRepository.Find(item => item.CreationDate >= startDate && item.CreationDate <= endDate && item.IsDeleted == false && item.IsVisible == true && item.CategoryId == categoryId);
            }
        }

        /// <summary>
        /// Gets the questions.
        /// </summary>
        /// <param name="questionIds">The question ids.</param>
        /// <returns>The questions.</returns>
        public IEnumerable<Question> GetQuestions(IEnumerable<int> questionIds)
        {
            return QuestionRepository.Find(item => questionIds.Contains(item.Id) && item.IsDeleted == false);
        }

        #endregion
    }
}