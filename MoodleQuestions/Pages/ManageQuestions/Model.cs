using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using QuestionsDAL;

namespace MoodleQuestions.Pages.ManageQuestions
{
    public class Model
    {
        #region Methods

        public IEnumerable<Question> GetUserQuestions(Guid userId)
        {
            using (var context = new Entities())
            {
                return (from question in context.Questions
                        where question.AuthorId == userId && question.IsDeleted == false
                        select question).ToList();
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

        public IEnumerable<Student> GetUsers()
        {
            return PermissionHelper.GetStudents();
        }

        public ICollection<QuestionCategory> GetQuestionCategories()
        {
            using (var context = new Entities())
            {
                return (from item in context.QuestionCategories select item).ToList();
            }
        }

        public void CreateCategory(string name, int? parentId)
        {
            using (var context = new Entities())
            {
                var category = new QuestionCategory()
                {
                    Name = name,
                    ParentCategoryId = parentId
                };

                context.QuestionCategories.Add(category);
                context.SaveChanges();
            }
        }

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