using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MoodleQuestions.Pages.CreateQuestion
{
    public class BasePresenter
    {
        #region Fields

        private IView _view;
        private Model _model;

        #endregion

        #region Constructors

        public BasePresenter(IView view)
        {
            _view = view;
            _model = new Model();
        }

        #endregion

        #region Methods

        public XElement GenerateXML()
        {
            var question = _view.GetQuestion();
            var xmlGenerator = new XmlGenerator();
            return xmlGenerator.GenerateXml(question);
        }

        #endregion
    }
}