using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuestionsDAL;

namespace MoodleQuestions.Pages.CreateQuestion
{
    public class LoggedUserPresenter
    {
        #region Fields

        private IView _view;
        private Model _model;

        #endregion

        #region Constructors

        public LoggedUserPresenter(IView view)
        {
            _view = view;
            _model = new Model();
        }

        #endregion

        #region Methods

        public void SaveQuestion()
        {
            var question = _view.GetQuestion();
            _model.SaveQuestion(question);
        }

        #endregion
    }
}