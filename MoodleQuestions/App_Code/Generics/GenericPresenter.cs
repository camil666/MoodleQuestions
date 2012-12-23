using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodleQuestions.Generics
{
    public abstract class GenericPresenter<TView, TModel>
        where TModel : new()
    {
        #region Properties

        protected TModel Model { get; private set; }

        protected TView View { get; private set; }

        #endregion

        #region Constructors

        public GenericPresenter(TView view)
        {
            View = view;
            Model = new TModel();
        }

        #endregion
    }
}