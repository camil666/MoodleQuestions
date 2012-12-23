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

        #endregion
    }
}