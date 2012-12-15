using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoodleQuestions.Controls;
using QuestionsDAL;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public class BasePresenter
    {
        #region Fields

        private IBaseView _view;

        #endregion

        #region Properties

        protected BaseModel Model { get; set; }

        #endregion

        #region Constructors

        public BasePresenter(IBaseView view)
        {
            _view = view;
        }

        #endregion

        #region Methods

        public void SetQuestion()
        {
            _view.QuestionToDisplay = Model.GetQuestion(_view.QuestionId);
        }

        #endregion
    }
}