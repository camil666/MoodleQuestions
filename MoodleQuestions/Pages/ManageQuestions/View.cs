using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoodleQuestions.Pages.ManageQuestions
{
    public abstract class View<TPresenter> : WebControl, IView
        where TPresenter : IPresenter
    {
        #region Fields

        private GridView _questionGridView;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the question ids.
        /// </summary>
        /// <value>
        /// The question ids.
        /// </value>
        public IEnumerable<int> QuestionIds
        {
            get
            {
                var results = new List<int>();
                foreach (GridViewRow row in _questionGridView.Rows)
                {
                    var checkBox = (row.Controls[1] as DataControlFieldCell).Controls[0] as CheckBox;

                    if (checkBox.Checked)
                    {
                        results.Add((int)_questionGridView.DataKeys[row.RowIndex].Value);
                    }
                }

                return results;
            }
        }

        /// <summary>
        /// Gets or sets the question grid data source.
        /// </summary>
        /// <value>
        /// The question grid data source.
        /// </value>
        public object QuestionGridDataSource
        {
            get { return _questionGridView.DataSource; }
            set { _questionGridView.DataSource = value; }
        }

        /// <summary>
        /// Gets or sets the presenter.
        /// </summary>
        /// <value>
        /// The presenter.
        /// </value>
        protected TPresenter Presenter { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="View{TPresenter}" /> class.
        /// </summary>
        protected View()
            : base(HtmlTextWriterTag.Div)
        {
            _questionGridView = new GridView()
                {
                    AutoGenerateColumns = false,
                    CssClass = "questionGrid",
                    DataKeyNames = new string[] { "Id" }
                };

            var idField = new BoundField()
            {
                Visible = false,
                DataField = "Id"
            };

            _questionGridView.Columns.Add(idField);

            var selectionField = new TemplateField()
            {
                ItemTemplate = new SelectionTemplate(),
                HeaderTemplate = new SelectionTemplate()
            };

            _questionGridView.Columns.Add(selectionField);

            var nameField = new BoundField()
            {
                HeaderText = HttpContext.GetGlobalResourceObject("Strings", "NameHeaderText").ToString(),
                DataField = "Name"
            };

            _questionGridView.Columns.Add(nameField);

            var creationDateField = new BoundField()
            {
                HeaderText = HttpContext.GetGlobalResourceObject("Strings", "CreationDateHeaderText").ToString(),
                DataField = "CreationDate"
            };

            _questionGridView.Columns.Add(creationDateField);

            var modificationDateField = new BoundField()
            {
                HeaderText = HttpContext.GetGlobalResourceObject("Strings", "ModificationDateHeaderText").ToString(),
                DataField = "ModificationDate"
            };

            _questionGridView.Columns.Add(modificationDateField);

            var ratingField = new BoundField()
            {
                HeaderText = HttpContext.GetGlobalResourceObject("Strings", "RatingHeaderText").ToString(),
                DataField = "Rating"
            };

            _questionGridView.Columns.Add(ratingField);

            var detailsField = new HyperLinkField()
            {
                HeaderText = HttpContext.GetGlobalResourceObject("Strings", "DetailsLabelText").ToString(),
                Text = HttpContext.GetGlobalResourceObject("Strings", "DetailsLabelText").ToString(),
                DataNavigateUrlFields = new string[] { "Id" },
                DataNavigateUrlFormatString = "QuestionDetails.aspx?q={0}",
                ShowHeader = false
            };

            _questionGridView.Columns.Add(detailsField);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Controls.Add(_questionGridView);

            var generateXmlButton = new Button()
            {
                Text = HttpContext.GetGlobalResourceObject("Strings", "GenerateXMLButtonText").ToString(),
            };

            generateXmlButton.Click += GenerateXmlButton_Click;
            Controls.Add(generateXmlButton);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Load" /> event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Page.ClientScript.RegisterClientScriptInclude("QuestionManagementScripts", ResolveClientUrl("~/Scripts/QuestionManagementScripts.js"));

            if (!Page.IsPostBack)
            {
                _questionGridView.DataBind();
            }
        }

        private void GenerateXmlButton_Click(object sender, EventArgs e)
        {
            var xml = Presenter.GenerateXml();
            Page.Response.ContentType = "text/xml";
            Page.Response.AppendHeader("content-disposition", "attachment;filename=Question.xml");
            xml.Save(Page.Response.OutputStream);
            Page.Response.End();
        }

        #endregion
    }
}