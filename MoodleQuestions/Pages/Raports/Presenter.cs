using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodleQuestions.Pages.Raports
{
    public class Presenter
    {
        #region Fields

        private Model _model;
        private IView _view;

        #endregion

        #region Constructors

        public Presenter(IView view)
        {
            _view = view;
            _model = new Model();
        }

        #endregion

        #region Methods

        public void SetupDropDown()
        {
            _view.DropDownDataSource = _model.GetStudents();
        }

        public void DisplayUserReport()
        {
            var questions = _model.GetStudentQuestions(_view.SelectedStudentId, _view.StartDate, _view.EndDate);
            if (questions.Count() > 0)
            {
                var ratedQuestions = from question in questions
                                     where question.Rating != null
                                     select question;

                var ratingsSum = ratedQuestions.Sum(item => item.Rating);

                _view.QuestionCount = questions.Count().ToString();
                _view.RatedQuestionCount = ratedQuestions.Count().ToString();
                _view.UnratedQuestionCount = (questions.Count() - ratedQuestions.Count()).ToString();
                if (ratedQuestions.Count() > 0)
                {
                    _view.AverageRating = Math.Round(ratingsSum.Value / Convert.ToDecimal(ratedQuestions.Count()), 2).ToString();
                }
            }
        }

        #endregion
    }
}