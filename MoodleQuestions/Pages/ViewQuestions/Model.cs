using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuestionsDAL;

namespace MoodleQuestions.Pages.ViewQuestions
{
    public class Model
    {
        #region Methods

        public IEnumerable<QuestionCategory> GetQuestionCategories()
        {
            using (var context = new Entities())
            {
                return (from item in context.QuestionCategories select item).ToList();
            }
        }

        public IEnumerable<Question> GetViewableQuestions(DateTime? startDate, DateTime? endDate)
        {
            using (var context = new Entities())
            {
                if (startDate == null || endDate == null)
                {
                    return (from item in context.Questions.Include("Author").Include("QuestionCategory").Include("QuestionType").Include("QuestionAnswers")
                            where item.IsVisible == true && item.IsDeleted == false
                            select item).ToList();
                }
                else
                {
                    return (from item in context.Questions.Include("Author").Include("QuestionCategory").Include("QuestionType").Include("QuestionAnswers")
                            where item.CreationDate >= startDate && item.CreationDate <= endDate && item.IsDeleted == false && item.IsVisible == true
                            select item).ToList();
                }
            }
        }

        public IEnumerable<Question> GetViewableQuestions(DateTime? startDate, DateTime? endDate, int? categoryId)
        {
            using (var context = new Entities())
            {
                if (startDate == null || endDate == null)
                {
                    return (from item in context.Questions.Include("Author").Include("QuestionCategory").Include("QuestionType").Include("QuestionAnswers")
                            where item.IsVisible == true && item.IsDeleted == false && item.CategoryId == categoryId
                            select item).ToList();
                }
                else
                {
                    return (from item in context.Questions.Include("Author").Include("QuestionCategory").Include("QuestionType").Include("QuestionAnswers")
                            where item.CreationDate >= startDate && item.CreationDate <= endDate && item.IsDeleted == false && item.IsVisible == true && item.CategoryId == categoryId
                            select item).ToList();
                }
            }
        }

        public IEnumerable<Question> GetQuestions(IEnumerable<int> questionIds)
        {
            using (var context = new Entities())
            {
                return (from item in context.Questions.Include("Author").Include("QuestionCategory").Include("QuestionType").Include("QuestionAnswers")
                        where questionIds.Contains(item.Id) && item.IsDeleted == false
                        select item).ToList();
            }
        }

        #endregion
    }
}