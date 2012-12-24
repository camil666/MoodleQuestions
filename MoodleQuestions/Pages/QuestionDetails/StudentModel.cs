using System;
using System.Linq;
using QuestionsDAL;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public class StudentModel : Model
    {
        #region Methods

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <param name="modifiedQuestion">The modified question.</param>
        public void SaveChanges(Question modifiedQuestion)
        {
            using (var context = new Entities())
            {
                var selectedQuestion = (from item in context.Questions.Include("QuestionCategory").Include("QuestionAnswers")
                                        where item.Id == modifiedQuestion.Id
                                        select item).FirstOrDefault();

                selectedQuestion.Content = modifiedQuestion.Content;
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

        #endregion
    }
}