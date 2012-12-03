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

        protected Question Question { get; set; }

        protected Model Model { get; set; }

        #endregion

        #region Constructors

        public BasePresenter(IBaseView view)
        {
            _view = view;
        }

        #endregion

        #region Methods

        public virtual void SetQuestionDetails()
        {
            Question = Model.GetQuestion(_view.QuestionId);
            if (Question == null)
            {
                return;
            }

            _view.QuestionCreationDate = Question.CreationDate.ToShortDateString();
            if (Question.Author != null)
            {
                _view.QuestionAuthor = Question.Author.UserName;
            }
        }
        //TODO: dokonczyc
        public void SetQuestionContent()
        {
            if (Question.Rating == null)
            {
                _view.QuestionComposer.Question = Question;
            }
        }

        #endregion
    }
}