using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoodleQuestions.Pages.ManageQuestions
{
    //<asp:PlaceHolder runat="server" ID="ButtonsPlaceHolder">
    //    <asp:Button runat="server" ID="GenerateXMLButton" OnClick="GenerateXMLButton_Click" meta:resourcekey="GenerateXMLButton"></asp:Button>
    //</asp:PlaceHolder>--%>

    public class BaseView : WebControl, IBaseView
    {
        #region Fields

        private GridView _questionGridView;

        #endregion

        #region Properties

        public object QuestionGridDataSource
        {
            get { return _questionGridView.DataSource; }
            set { _questionGridView.DataSource = value; }
        }

        #endregion

        #region Constructors

        public BaseView()
            : base(HtmlTextWriterTag.Div)
        {
            _questionGridView = new GridView()
                {
                    AutoGenerateColumns = false
                };

            var idField = new BoundField()
            {
                Visible = false,
                DataField = "Id"
            };

            _questionGridView.Columns.Add(idField);

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
                DataNavigateUrlFormatString = "QuestionDetails.aspx?q={0}"
            };

            _questionGridView.Columns.Add(detailsField);

            var deleteField = new CommandField()
            {
                ButtonType = ButtonType.Button,
                ShowDeleteButton = true
            };

            _questionGridView.Columns.Add(deleteField);
        }

        #endregion

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Controls.Add(_questionGridView);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            _questionGridView.DataBind();
        }

        #endregion
    }
}