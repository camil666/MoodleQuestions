using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodleQuestions.Pages.ViewQuestions
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

        public void SetupRepeater()
        {
            _view.QuestionRepeaterDataSource = _model.GetViewableQuestions();
        }

        #endregion
    }
}