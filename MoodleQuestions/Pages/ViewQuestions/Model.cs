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

        public IEnumerable<Question> GetViewableQuestions()
        {
            using (var context = new Entities())
            {
                return (from item in context.Questions.Include("Author").Include("QuestionCategory").Include("QuestionType").Include("QuestionAnswers")
                        where item.IsVisible == true && item.IsDeleted == false
                        select item).ToList();
            }
        }

        #endregion
    }
}