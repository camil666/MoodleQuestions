using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuestionsDAL;

namespace MoodleQuestions.Pages.Reports
{
    public class BasePresenter
    {
        #region Properties

        protected Model Model { get; set; }

        protected IBaseView View { get; set; }

        #endregion

        #region Constructors

        public BasePresenter(IBaseView view)
        {
            View = view;
            Model = new Model();
        }

        #endregion

        #region Methods

        public void DisplayUserReport()
        {
            IEnumerable<Question> questions = null;

            if (View.SelectedStudentId == Guid.Empty)
            {
                questions = Model.GetAllQuestions(View.StartDate, View.EndDate);
            }
            else
            {
                questions = Model.GetStudentQuestions(View.SelectedStudentId, View.StartDate, View.EndDate);
            }

            if (questions != null && questions.Count() > 0)
            {
                var ratedQuestions = from question in questions
                                     where question.Rating != null
                                     select question;

                var ratingsSum = ratedQuestions.Sum(item => item.Rating);

                View.QuestionCount = questions.Count().ToString();
                View.RatedQuestionCount = ratedQuestions.Count().ToString();
                View.UnratedQuestionCount = (questions.Count() - ratedQuestions.Count()).ToString();
                if (ratedQuestions.Count() > 0)
                {
                    View.AverageRating = Math.Round(ratingsSum.Value / Convert.ToDecimal(ratedQuestions.Count()), 2).ToString();
                }
            }
            else
            {
                View.QuestionCount = Constants.EmptyText;
                View.RatedQuestionCount = Constants.EmptyText;
                View.UnratedQuestionCount = Constants.EmptyText;
                View.AverageRating = Constants.EmptyText;
            }
        }

        #endregion
    }
}