using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuestionsDAL;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public class SupervisorModel : Model
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
                selectedQuestion.CategoryId = modifiedQuestion.CategoryId;
                selectedQuestion.Name = modifiedQuestion.Name;
                selectedQuestion.Rating = modifiedQuestion.Rating;
                selectedQuestion.ModificationDate = DateTime.Now;
                selectedQuestion.IsVisible = modifiedQuestion.IsVisible;
                for (int i = 0; i < selectedQuestion.QuestionAnswers.Count; ++i)
                {
                    selectedQuestion.QuestionAnswers.ElementAt(i).Content = modifiedQuestion.QuestionAnswers.ElementAt(i).Content;
                    selectedQuestion.QuestionAnswers.ElementAt(i).Fraction = modifiedQuestion.QuestionAnswers.ElementAt(i).Fraction;
                }

                context.SaveChanges();
            }
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