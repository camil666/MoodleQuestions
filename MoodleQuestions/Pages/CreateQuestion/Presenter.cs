using System.Xml.Linq;

namespace MoodleQuestions.Pages.CreateQuestion
{
    public class Presenter
    {
        #region Fields

        protected IView _view;
        protected Model _model;

        #endregion

        #region Constructors

        public Presenter(IView view)
        {
            _view = view;
            _model = new Model();
        }

        #endregion

        #region Methods

        public void SaveQuestion()
        {
            var question = _view.GetQuestion();
            _model.SaveQuestion(question);
        }

        public XElement GenerateXML()
        {
            var question = _view.GetQuestion();
            var xmlGenerator = new XmlGenerator();
            return xmlGenerator.GenerateXml(question);
        }

        #endregion
    }
}