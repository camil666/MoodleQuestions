using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using QuestionsDAL;

namespace MoodleQuestions.Repositories
{
    public static class QuestionCategoryRepository
    {
        #region Methods

        /// <summary>
        /// Adds the specified category.
        /// </summary>
        /// <param name="category">The category.</param>
        public static void Add(QuestionCategory category)
        {
            using (var context = new Entities())
            {
                context.QuestionCategories.Add(category);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>Found question category.</returns>
        public static QuestionCategory GetById(int id)
        {
            using (var context = new Entities())
            {
                return (from item in context.QuestionCategories
                        where item.Id == id
                        select item).FirstOrDefault();
            }
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>All the categories.</returns>
        public static IEnumerable<QuestionCategory> GetAll()
        {
            using (var context = new Entities())
            {
                return (from item in context.QuestionCategories
                        select item).ToList();
            }
        }

        /// <summary>
        /// Finds the specified categories.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Found categories.</returns>
        public static IEnumerable<QuestionCategory> Find(Expression<Func<QuestionCategory, bool>> query)
        {
            using (var context = new Entities())
            {
                return (from question in context.QuestionCategories
                            .Where(query)
                        select question).ToList();
            }
        }

        #endregion
    }
}