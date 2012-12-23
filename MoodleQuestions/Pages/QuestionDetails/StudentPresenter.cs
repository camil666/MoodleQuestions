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
    public class StudentPresenter : Presenter<IStudentView, StudentModel>
    {
        #region Constructors

        public StudentPresenter(IStudentView view)
            : base(view)
        {
        }

        #endregion

        #region Methods

        public void SaveChanges()
        {
            var newQuestion = View.ChangedQuestion;
            if (newQuestion != null)
            {
                newQuestion.Id = View.QuestionId;
            }
            else
            {
                newQuestion = Model.GetQuestion(View.QuestionId);
                newQuestion.IsVisible = View.QuestionIsVisible;
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