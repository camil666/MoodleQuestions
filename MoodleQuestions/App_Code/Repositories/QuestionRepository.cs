using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using QuestionsDAL;

namespace MoodleQuestions.Repositories
{
    public static class QuestionRepository
    {
        #region Methods

        /// <summary>
        /// Adds the specified question.
        /// </summary>
        /// <param name="question">The question.</param>
        public static void Add(Question question)
        {
            using (var context = new Entities())
            {
                context.Questions.Add(question);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>Found question.</returns>
        public static Question GetById(int id)
        {
            using (var context = new Entities())
            {
                return (from item in context.Questions.Include("Author").Include("QuestionCategory").Include("QuestionAnswers")
                        where item.Id == id
                        select item).FirstOrDefault();
            }
        }

        /// <summary>
        /// Finds the specified questions.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Found questions.</returns>
        public static IEnumerable<Question> Find(Expression<Func<Question, bool>> query)
        {
            using (var context = new Entities())
            {
                return (from question in context.Questions.Include("Author").Include("QuestionCategory").Include("QuestionAnswers")
                            .Where(query)
                        select question).ToList();
            }
        }

        /// <summary>
        /// Marks question as deleted.
        /// </summary>
        /// <param name="id">The id.</param>
        public static void MarkAsDeleted(int id)
        {
            using (var context = new Entities())
            {
                var question = (from item in context.Questions
                                where item.Id == id
                                select item).FirstOrDefault();

                question.IsDeleted = true;

                context.SaveChanges();
            }
        }

        #endregion
    }
}