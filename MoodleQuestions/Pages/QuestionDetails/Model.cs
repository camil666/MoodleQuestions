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

        public ICollection<QuestionCategory> GetQuestionCategories()
        {
            using (var context = new Entities())
            {
                return (from item in context.QuestionCategories select item).ToList();
            }
        }

        public void SaveChanges(Question oldQuestion, Question modifiedQuestion)
        {
            using (var context = new Entities())
            {
                var selectedQuestion = (from item in context.Questions.Include("QuestionCategory").Include("QuestionAnswers")
                                        where item.Id == oldQuestion.Id
                                        select item).FirstOrDefault();

                selectedQuestion.CategoryId = modifiedQuestion.CategoryId;
                selectedQuestion.Content = modifiedQuestion.Content;
                selectedQuestion.Name = modifiedQuestion.Name;
                selectedQuestion.Rating = modifiedQuestion.Rating;
                selectedQuestion.ModificationDate = DateTime.Now;
                for (int i = 0; i < selectedQuestion.QuestionAnswers.Count; ++i)
                {
                    selectedQuestion.QuestionAnswers.ElementAt(i).Content = modifiedQuestion.QuestionAnswers.ElementAt(i).Content;
                    selectedQuestion.QuestionAnswers.ElementAt(i).Fraction = modifiedQuestion.QuestionAnswers.ElementAt(i).Fraction;
                }

                context.SaveChanges();
            }
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