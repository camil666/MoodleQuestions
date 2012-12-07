using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodleQuestions.Pages.ManageQuestions
{
    public class SupervisorPresenter : BasePresenter
    {
        #region Fields

        private ISupervisorView _view;

        #endregion

        #region Constructors

        public SupervisorPresenter(ISupervisorView view)
        {
            _view = view;
        }

        #endregion

        #region Methods

        public void SetupUserDropDown()
        {
            _view.UserDropDownDataSource = Model.GetUsers();
        }
        //TODO: Poprawic na pobieranie pytan wybranego uzytkownika albozrobic finda z kilkoma filtrami
        public override void SetupGrid()
        {
            _view.QuestionGridDataSource = Model.GetAllQuestions();
        }

        #endregion
    }
}