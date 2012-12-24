using System.Xml.Linq;
using MoodleQuestions.Generics;

namespace MoodleQuestions.Pages.ManageQuestions
{
    public abstract class Presenter<TView, TModel> : GenericPresenter<TView, TModel>, IPresenter
        where TView : IView
        where TModel : Model, new()
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Presenter{TView,TModel}" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        protected Presenter(TView view)
            : base(view)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Generates the XML.
        /// </summary>
        /// <returns>
        /// Generated xml.
        /// </returns>
        public XElement GenerateXml()
        {
            var questions = Model.GetQuestions(View.QuestionIds);
            var xmlGenerator = new XmlGenerator();
            return xmlGenerator.GenerateXml(questions);
        }

        #endregion
    }
}