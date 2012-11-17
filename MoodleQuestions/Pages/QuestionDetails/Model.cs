using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuestionsDAL;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public class Model
    {
        #region Methods

        public Question GetQuestion(int questionId)
        {
            using (var context = new Entities())
            {
                return (from item in context.Questions.Include("Author").Include("QuestionCategory").Include("QuestionType").Include("QuestionAnswers")
                        where item.Id == questionId
                        select item).FirstOrDefault();
            }
        }

        #endregion
    }
}