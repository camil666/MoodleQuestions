using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodleQuestions.Pages.ManageQuestions
{
    public class BasePresenter
    {
        #region Properties

        protected Model Model { get; set; }

        #endregion

        #region Constructors

        public BasePresenter()
        {
            Model = new Model();
        }

        #endregion

        #region Methods

        public virtual void SetupGrid()
        {
        }

        #endregion
    }
}