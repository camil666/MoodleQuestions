using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuestionsDAL;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public class BaseModel
    {
        #region Methods

        public Question GetQuestion(int questionId)
        {
            using (var context = new Entities())
            {
                return (from item in context.Questions.Include("Author").Include("QuestionCategory").Include("QuestionType").Include("QuestionAnswers")
                        where item.Id == questionId && item.IsDeleted == false
                        select item).FirstOrDefault();
            }
        }

        public virtual void SaveChanges(Question modifiedQuestion)
        {
        }

        public void DeleteQuestion(int id)
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