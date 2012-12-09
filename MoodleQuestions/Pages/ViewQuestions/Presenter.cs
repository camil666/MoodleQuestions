using System.Xml.Linq;

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

        public XElement GenerateXML()
        {
            var questionIds = _view.GetQuestionIds();
            var questions = _model.GetQuestions(questionIds);
            var xmlGenerator = new XmlGenerator();
            return xmlGenerator.GenerateXml(questions);
        }

        #endregion
    }
}