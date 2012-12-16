using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuestionsDAL;

namespace MoodleQuestions.Pages.QuestionDetails
{
    public class StudentPresenter : BasePresenter
    {
        #region Fields

        private IStudentView _view;

        #endregion

        #region Constructors

        public StudentPresenter(IStudentView view)
            : base(view)
        {
            _view = view;
            Model = new StudentModel();
        }

        #endregion

        #region Methods

        public void SaveChanges()
        {
            var newQuestion = _view.ChangedQuestion;
            if (newQuestion != null)
            {
                newQuestion.Id = _view.QuestionId;
            }
            else
            {
                newQuestion = Model.GetQuestion(_view.QuestionId);
                newQuestion.IsVisible = _view.QuestionIsVisible;
            }

            Model.SaveChanges(newQuestion);
        }

        public void DeleteQuestion(int id)
        {
            Model.DeleteQuestion(id);
        }

        #endregion
    }
}