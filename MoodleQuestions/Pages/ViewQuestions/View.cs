using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoodleQuestions.Controls;
using QuestionsDAL;

namespace MoodleQuestions.Pages.ViewQuestions
{
    public class View : WebControl, IView
    {
        #region Fields

        private Presenter _presenter;
        private Repeater _questionRepeater;
        private Button _generateXMLButton;
        private DateFilter _dateFilter;
        private Panel _repeaterPanel;

        #endregion

        #region Properties

        public object QuestionRepeaterDataSource
        {
            get { return _questionRepeater.DataSource; }
            set { _questionRepeater.DataSource = value; }
        }

        public DateTime? StartDate
        {
            get { return _dateFilter.StartDate; }
        }

        public DateTime? EndDate
        {
            get { return _dateFilter.EndDate; }
        }

        #endregion

        #region Constructors

        public View()
            : base(HtmlTextWriterTag.Div)
        {
            _presenter = new Presenter(this);
            _dateFilter = new DateFilter();
            _generateXMLButton = new Button()
            {
                Text = HttpContext.GetGlobalResourceObject("Strings", "GenerateXMLButtonText").ToString()
            };

            _generateXMLButton.Click += GenerateXMLButton_Click;
            _questionRepeater = new Repeater()
                {
                    ItemTemplate = new QuestionItemTemplate() { CheckboxText = HttpContext.GetGlobalResourceObject("Strings", "QuestionViewCheckboxText").ToString() }
                };
        }

        #endregion

        #region Methods

        public IEnumerable<int> GetQuestionIds()
        {
            var list = new List<int>();

            foreach (RepeaterItem item in _questionRepeater.Items)
            {
                var checkBox = item.Controls[0].Controls[0] as CheckBox;
                if (checkBox.Checked == true)
                {
                    list.Add(int.Parse((checkBox.Parent as WebControl).Attributes["QuestionId"]));
                }
            }

            return list;
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Controls.Add(_dateFilter);
            var searchButton = new Button()
            {
                Text = HttpContext.GetGlobalResourceObject("Strings", "SearchButtonText").ToString()
            };

            searchButton.Click += SearchButton_Click;
            Controls.Add(searchButton);
            _repeaterPanel = new Panel() { CssClass = "questionViewer" };
            _repeaterPanel.Controls.Add(_questionRepeater);
            Controls.Add(_repeaterPanel);
            Controls.Add(_generateXMLButton);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (!Page.IsPostBack)
            {
                _presenter.DisplayViewableQuestions();
                _questionRepeater.DataBind();
            }

            if (_questionRepeater.Items.Count == 0)
            {
                _repeaterPanel.Controls.Add(new LiteralControl(HttpContext.GetGlobalResourceObject("Strings", "QuestionsNotFound").ToString()));
            }
        }

        private void GenerateXMLButton_Click(object sender, EventArgs e)
        {
            var xml = _presenter.GenerateXML();
            Page.Response.ContentType = "text/xml";
            Page.Response.AppendHeader("content-disposition", "attachment;filename=Question.xml");
            xml.Save(Page.Response.OutputStream);
            Page.Response.End();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            _presenter.DisplayViewableQuestions();
            _questionRepeater.DataBind();
        }

        #endregion
    }
}