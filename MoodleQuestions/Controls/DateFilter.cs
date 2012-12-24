using System;
using System.Globalization;
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

        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public DateTime? StartDate
        {
            get
            {
                DateTime date;
                if (DateTime.TryParseExact(_endDateTextBox.Text, "dd.mm.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    return date;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public DateTime? EndDate
        {
            get
            {
                DateTime date;
                if (DateTime.TryParseExact(_endDateTextBox.Text, "dd.mm.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    return date;
                }

                return null;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DateFilter" /> class.
        /// </summary>
        public DateFilter()
            : base(HtmlTextWriterTag.Div)
        {
            _startDateTextBox = new TextBox() { ID = "startDateTextBox", ClientIDMode = ClientIDMode.Static };
            _endDateTextBox = new TextBox() { ID = "endDateTextBox", ClientIDMode = ClientIDMode.Static };
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
            Controls.Add(new Label() { Text = HttpContext.GetGlobalResourceObject("Strings", "StartDateLabelText").ToString(), Width = 180 });
            Controls.Add(_startDateTextBox);
            Controls.Add(new LiteralControl("<br>"));
            Controls.Add(new Label() { Text = HttpContext.GetGlobalResourceObject("Strings", "EndDateLabelText").ToString(), Width = 180 });
            Controls.Add(_endDateTextBox);
            Controls.Add(new LiteralControl("<br>"));
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Load" /> event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Page.ClientScript.RegisterClientScriptInclude("DatePickersScripts", ResolveClientUrl("~/Scripts/DatePickersScripts.js"));
            Page.ClientScript.RegisterClientScriptInclude("DatePickerLocalization", ResolveClientUrl("~/Scripts/jquery.ui.datepicker-pl.js"));
        }

        #endregion
    }
}