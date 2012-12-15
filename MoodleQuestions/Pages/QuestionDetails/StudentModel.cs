using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuestionsDAL;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public class StudentModel : BaseModel
    {
        #region Methods

        public override void SaveChanges(Question modifiedQuestion)
        {
            using (var context = new Entities())
            {
                var selectedQuestion = (from item in context.Questions.Include("QuestionCategory").Include("QuestionAnswers")
                                        where item.Id == modifiedQuestion.Id
                                        select item).FirstOrDefault();

                selectedQuestion.Content = modifiedQuestion.Content;
                selectedQuestion.ModificationDate = DateTime.Now;
                for (int i = 0; i < selectedQuestion.QuestionAnswers.Count; ++i)
                {
                    selectedQuestion.QuestionAnswers.ElementAt(i).Content = modifiedQuestion.QuestionAnswers.ElementAt(i).Content;
                    selectedQuestion.QuestionAnswers.ElementAt(i).Fraction = modifiedQuestion.QuestionAnswers.ElementAt(i).Fraction;
                }

                context.SaveChanges();
            }
        }

        //public void DeleteQuestion(int id)
        //{
        //    using (var context = new Entities())
        //    {
        //        var selectedQuestion = (from item in context.Questions.Include("QuestionCategory").Include("QuestionAnswers")
        //                                where item.Id == id
        //                                select item).FirstOrDefault();

        //        context.Questions.Remove(selectedQuestion);
        //        context.SaveChanges();
        //    }
        //}

        #endregion
    }
}