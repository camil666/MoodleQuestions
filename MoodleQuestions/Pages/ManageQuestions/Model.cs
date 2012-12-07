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
                        where question.AuthorId == userId
                        select question).ToList();
            }
        }

        public IEnumerable<Student> GetUsers()
        {
            return PermissionHelper.GetStudents();
        }

        #endregion
    }
}