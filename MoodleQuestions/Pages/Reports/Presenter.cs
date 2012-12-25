using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoodleQuestions.Generics;
using QuestionsDAL;

namespace MoodleQuestions.Pages.Reports
{
    public abstract class Presenter<TView, TModel> : GenericPresenter<TView, TModel>, IPresenter
        where TView : IView
        where TModel : Model, new()
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Presenter{TView,TModel}" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        protected Presenter(TView view)
            : base(view)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Displays the user report.
        /// </summary>
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
                View.QuestionCount = "-";
                View.RatedQuestionCount = "-";
                View.UnratedQuestionCount = "-";
                View.AverageRating = "-";
            }
        }

        #endregion
    }
}