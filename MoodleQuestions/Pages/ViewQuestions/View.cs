using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoodleQuestions.Controls;

namespace MoodleQuestions.Pages.ViewQuestions
{
    public class View : WebControl, IView
    {
        #region Fields

        private Presenter _presenter;
        private Repeater _questionRepeater;

        #endregion

        #region Properties

        public object QuestionRepeaterDataSource
        {
            get { return _questionRepeater.DataSource; }
            set { _questionRepeater.DataSource = value; }
        }

        #endregion

        #region Constructors

        public View()
            : base(HtmlTextWriterTag.Div)
        {
            _presenter = new Presenter(this);
            _questionRepeater = new Repeater()
                {
                    ItemTemplate = new QuestionItemTemplate()
                };
        }

        #endregion

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Controls.Add(_questionRepeater);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            _presenter.SetupRepeater();
            _questionRepeater.DataBind();
        }

        #endregion
    }
}