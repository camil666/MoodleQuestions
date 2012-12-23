using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using MoodleQuestions.Generics;

namespace MoodleQuestions.Pages.ManageQuestions
{
    public abstract class Presenter<TView, TModel> : GenericPresenter<TView, TModel>, IPresenter
        where TView : IView
        where TModel : Model, new()
    {
        #region Constructors

        public Presenter(TView view)
            : base(view)
        {
        }

        #endregion

        #region Methods

        public XElement GenerateXml()
        {
            var questions = Model.GetQuestions(View.QuestionIds);
            var xmlGenerator = new XmlGenerator();
            return xmlGenerator.GenerateXml(questions);
        }

        #endregion
    }
}