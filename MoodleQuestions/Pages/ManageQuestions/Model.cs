using System;
using System.Collections.Generic;
using System.Linq;
using MoodleQuestions.Repositories;
using QuestionsDAL;

namespace MoodleQuestions.Pages.ManageQuestions
{
    public class Model
    {
        #region Methods

        /// <summary>
        /// Gets the user questions.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>User questions.</returns>
        public IEnumerable<Question> GetUserQuestions(Guid userId)
        {
            return QuestionRepository.Find(question => question.AuthorId == userId && question.IsDeleted == false);
        }

        /// <summary>
        /// Gets the questions.
        /// </summary>
        /// <param name="questionIds">The question ids.</param>
        /// <returns>The questions.</returns>
        public IEnumerable<Question> GetQuestions(IEnumerable<int> questionIds)
        {
            return QuestionRepository.Find(question => questionIds.Contains(question.Id) && question.IsDeleted == false);
        }

        /// <summary>
        /// Gets the question categories.
        /// </summary>
        /// <returns>All the question categories.</returns>
        public IEnumerable<QuestionCategory> GetQuestionCategories()
        {
            return QuestionCategoryRepository.GetAll();
        }

        /// <summary>
        /// Creates the category.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="parentId">The parent id.</param>
        public void CreateCategory(string name, int? parentId)
        {
            var category = new QuestionCategory()
            {
                Name = name,
                ParentCategoryId = parentId
            };

            QuestionCategoryRepository.Add(category);
        }

        /// <summary>
        /// Deletes the category.
        /// </summary>
        /// <param name="id">The id.</param>
        public void DeleteCategory(int id)
        {
            using (var context = new Entities())
            {
                var categoryToBeDeleted = (from item in context.QuestionCategories
                                           where item.Id == id
                                           select item).FirstOrDefault();

                var questions = from item in context.Questions
                                where item.CategoryId == id
                                select item;

                foreach (var question in questions)
                {
                    question.CategoryId = null;
                }

                var childCategories = from item in context.QuestionCategories
                                      where item.ParentCategoryId == id
                                      select item;

                foreach (var category in childCategories)
                {
                    category.ParentCategoryId = categoryToBeDeleted.ParentCategoryId;
                }

                context.QuestionCategories.Remove(categoryToBeDeleted);
                context.SaveChanges();
            }
        }

        #endregion
    }
}