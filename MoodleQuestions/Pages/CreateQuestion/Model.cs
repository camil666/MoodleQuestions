using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuestionsDAL;

namespace MoodleQuestions.Pages.CreateQuestion
{
    public class Model
    {
        #region Methods

        public void SaveQuestion(Question question)
        {
            using (var context = new Entities())
            {
                context.Questions.Add(question);
                context.SaveChanges();
            }
        }

        #endregion
    }
}