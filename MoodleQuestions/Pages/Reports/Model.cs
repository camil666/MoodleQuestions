using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using QuestionsDAL;

namespace MoodleQuestions.Pages.Reports
{
    public class Model
    {
        #region Methods

        public IEnumerable<Student> GetStudents()
        {
            return PermissionHelper.GetStudents();
        }

        public IEnumerable<Question> GetStudentQuestions(Guid studentId, DateTime? startDate, DateTime? endDate)
        {
            using (var context = new Entities())
            {
                return (from item in context.Questions.Include("Author").Include("QuestionCategory").Include("QuestionType").Include("QuestionAnswers")
                        where item.AuthorId == studentId && item.CreationDate >= startDate && item.CreationDate <= endDate && item.IsDeleted == false
                        select item).ToList();
            }
        }

        public IEnumerable<Question> GetAllQuestions(DateTime? startDate, DateTime? endDate)
        {
            using (var context = new Entities())
            {
                return (from item in context.Questions.Include("Author").Include("QuestionCategory").Include("QuestionType").Include("QuestionAnswers")
                        where item.CreationDate >= startDate && item.CreationDate <= endDate && item.IsDeleted == false
                        select item).ToList();
            }
        }

        #endregion
    }
}