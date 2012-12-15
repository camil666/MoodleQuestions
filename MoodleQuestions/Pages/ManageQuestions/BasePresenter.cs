using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MoodleQuestions.Pages.ManageQuestions
{
    public class BasePresenter
    {
        #region Properties

        protected Model Model { get; set; }

        protected IBaseView View { get; private set; }

        #endregion

        #region Constructors

        public BasePresenter(IBaseView view)
        {
            Model = new Model();
            View = view;
        }

        #endregion

        #region Methods

        public virtual void SetupGrid()
        {
        }

        public XElement GenerateXml()
        {
            var questions = Model.GetQuestions(View.QuestionIds);
            var xmlGenerator = new XmlGenerator();
            return xmlGenerator.GenerateXml(questions);
        }

        #endregion
    }
}