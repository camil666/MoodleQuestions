using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuestionsDAL;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public class SupervisorModel : BaseModel
    {
        #region Methods

        public override void SaveChanges(Question modifiedQuestion)
        {
            using (var context = new Entities())
            {
                var selectedQuestion = (from item in context.Questions.Include("QuestionCategory").Include("QuestionAnswers")
                                        where item.Id == modifiedQuestion.Id
                                        select item).FirstOrDefault();

                selectedQuestion.CategoryId = modifiedQuestion.CategoryId;
                selectedQuestion.Name = modifiedQuestion.Name;
                selectedQuestion.Rating = modifiedQuestion.Rating;
                selectedQuestion.ModificationDate = DateTime.Now;

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