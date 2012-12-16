using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoodleQuestions.Controls
{
    public class DateFilter : WebControl
    {
        #region Fields

        private TextBox _startDateTextBox;
        private TextBox _endDateTextBox;

        #endregion

        #region Properties

        public DateTime? StartDate
        {
            get
            {
                DateTime date;
                if (DateTime.TryParse(_startDateTextBox.Text, out date) == true)
                {
                    return date;
                }

                return null;
            }
        }

        public DateTime? EndDate
        {
            get
            {
                DateTime date;
                if (DateTime.TryParse(_endDateTextBox.Text, out date) == true)
                {
                    return date;
                }

                return null;
            }
        }

        #endregion

        #region Constructors

        public DateFilter()
            : base(HtmlTextWriterTag.Div)
        {
            _startDateTextBox = new TextBox() { ID = "startDateTextBox", ClientIDMode = ClientIDMode.Static };
            _endDateTextBox = new TextBox() { ID = "endDateTextBox", ClientIDMode = ClientIDMode.Static };
        }

        #endregion

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Controls.Add(new Label() { Text = HttpContext.GetGlobalResourceObject("Strings", "StartDateLabelText").ToString(), Width = 180 });
            Controls.Add(_startDateTextBox);
            Controls.Add(new LiteralControl("<br>"));
            Controls.Add(new Label() { Text = HttpContext.GetGlobalResourceObject("Strings", "EndDateLabelText").ToString(), Width = 180 });
            Controls.Add(_endDateTextBox);
            Controls.Add(new LiteralControl("<br>"));
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Page.ClientScript.RegisterClientScriptInclude("DatePickersScripts", ResolveClientUrl("~/Scripts/DatePickersScripts.js"));
        }

        #endregion
    }
}