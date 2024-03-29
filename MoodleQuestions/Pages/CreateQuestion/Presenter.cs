﻿using System.Xml.Linq;

namespace MoodleQuestions.Pages.CreateQuestion
{
    public class Presenter
    {
        #region Fields

        private IView _view;
        private Model _model;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Presenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public Presenter(IView view)
        {
            _view = view;
            _model = new Model();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Saves the question.
        /// </summary>
        public void SaveQuestion()
        {
            var question = _view.GetQuestion();
            _model.SaveQuestion(question);
        }

        /// <summary>
        /// Generates the Xml.
        /// </summary>
        /// <returns>Generated Xml.</returns>
        public XElement GenerateXml()
        {
            var question = _view.GetQuestion();
            return XmlGenerator.GenerateXml(question);
        }

        #endregion
    }
}