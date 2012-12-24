using System.Linq;
using System.Xml.Linq;
using QuestionsDAL;

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

        public void SetupCategories()
        {
            var questionCategories = _model.GetQuestionCategories();

            CategoryHelper.ConcatCategoryName(questionCategories);

            var orderedQuestionCategories = questionCategories.OrderBy(item => item.Name).ToList();
            orderedQuestionCategories.Insert(0, new QuestionCategory() { Id = 0, Name = "/" });
            orderedQuestionCategories.Insert(0, new QuestionCategory() { Id = -1, Name = "-" });
            _view.CategoryDataSource = orderedQuestionCategories;
        }

        public void DisplayViewableQuestions()
        {
            if (_view.SelectedCategoryId == -1)
            {
                _view.QuestionRepeaterDataSource = _model.GetViewableQuestions(_view.StartDate, _view.EndDate);
            }
            else if (_view.SelectedCategoryId == 0)
            {
                _view.QuestionRepeaterDataSource = _model.GetViewableQuestions(_view.StartDate, _view.EndDate, null);
            }
            else
            {
                _view.QuestionRepeaterDataSource = _model.GetViewableQuestions(_view.StartDate, _view.EndDate, _view.SelectedCategoryId);
            }
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