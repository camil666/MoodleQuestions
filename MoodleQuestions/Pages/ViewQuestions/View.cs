using System;
using System.Collections.Generic;
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
        private Button _generateXMLButton;
        private DateFilter _dateFilter;
        private Panel _repeaterPanel;
        private DropDownList _categoryDropDown;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the category data source.
        /// </summary>
        /// <value>
        /// The category data source.
        /// </value>
        public object CategoryDataSource
        {
            get { return _categoryDropDown.DataSource; }
            set { _categoryDropDown.DataSource = value; }
        }

        /// <summary>
        /// Gets or sets the question repeater data source.
        /// </summary>
        /// <value>
        /// The question repeater data source.
        /// </value>
        public object QuestionRepeaterDataSource
        {
            get { return _questionRepeater.DataSource; }
            set { _questionRepeater.DataSource = value; }
        }

        /// <summary>
        /// Gets the selected category id.
        /// </summary>
        /// <value>
        /// The selected category id.
        /// </value>
        public int SelectedCategoryId
        {
            get { return int.Parse(_categoryDropDown.SelectedValue); }
        }

        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public DateTime? StartDate
        {
            get { return _dateFilter.StartDate; }
        }

        /// <summary>
        /// Gets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public DateTime? EndDate
        {
            get { return _dateFilter.EndDate; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="View" /> class.
        /// </summary>
        public View()
            : base(HtmlTextWriterTag.Div)
        {
            _presenter = new Presenter(this);
            _categoryDropDown = new DropDownList()
            {
                DataTextField = "Name",
                DataValueField = "Id"
            };

            _dateFilter = new DateFilter();
            _generateXMLButton = new Button()
            {
                Text = ResourceHelper.GetString("GenerateXMLButtonText")
            };

            _generateXMLButton.Click += GenerateXMLButton_Click;
            _questionRepeater = new Repeater()
                {
                    ItemTemplate = new QuestionItemTemplate() { CheckBoxText = ResourceHelper.GetString("QuestionViewCheckboxText") }
                };
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the question ids.
        /// </summary>
        /// <returns>Ids of questions.</returns>
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

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            var categoryLabel = new Label() { Text = ResourceHelper.GetString("CategoryLabelText") };
            categoryLabel.Style.Add(HtmlTextWriterStyle.MarginRight, "114px");
            Controls.Add(categoryLabel);
            Controls.Add(_categoryDropDown);
            Controls.Add(_dateFilter);
            var searchButton = new Button()
            {
                Text = ResourceHelper.GetString("SearchButtonText")
            };

            searchButton.Click += SearchButton_Click;
            Controls.Add(searchButton);
            _repeaterPanel = new Panel() { CssClass = "questionViewer" };
            _repeaterPanel.Controls.Add(_questionRepeater);
            Controls.Add(_repeaterPanel);
            Controls.Add(_generateXMLButton);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.PreRender" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (!Page.IsPostBack)
            {
                _presenter.SetupCategories();
                _categoryDropDown.DataBind();
                _categoryDropDown.SelectedIndex = 0;
                _presenter.DisplayViewableQuestions();
                _questionRepeater.DataBind();
            }

            if (_questionRepeater.Items.Count == 0)
            {
                _repeaterPanel.Controls.Add(new LiteralControl(ResourceHelper.GetString("QuestionsNotFound")));
            }
        }

        private void GenerateXMLButton_Click(object sender, EventArgs e)
        {
            var xml = _presenter.GenerateXml();
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