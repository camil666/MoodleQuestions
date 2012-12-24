using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoodleQuestions.Controls;
using QuestionsDAL;

namespace MoodleQuestions.Pages.ViewQuestions
{
    public class QuestionItemTemplate : ITemplate
    {
        #region Properties

        /// <summary>
        /// Gets or sets the checkbox text.
        /// </summary>
        /// <value>
        /// The checkbox text.
        /// </value>
        public string CheckBoxText { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// When implemented by a class, defines the <see cref="T:System.Web.UI.Control" /> object that child controls and templates belong to.
        /// These child controls are in turn defined within an inline template.
        /// </summary>
        /// <param name="container">The <see cref="T:System.Web.UI.Control" /> object to contain the instances of controls from the inline template.</param>
        public void InstantiateIn(Control container)
        {
            var mainPanel = new Panel();
            mainPanel.DataBinding += MainPanel_DataBinding;
            container.Controls.Add(mainPanel);

            var checkBox = new CheckBox() { Text = CheckBoxText, TextAlign = TextAlign.Right };
            checkBox.LabelAttributes.CssStyle.Add(HtmlTextWriterStyle.Display, "inline-block");
            checkBox.LabelAttributes.CssStyle.Add(HtmlTextWriterStyle.MarginLeft, "4px");
            mainPanel.Controls.Add(checkBox);

            var viewer = new QuestionViewer();
            viewer.DataBinding += Viewer_DataBinding;
            mainPanel.Controls.Add(viewer);
        }

        private void MainPanel_DataBinding(object sender, EventArgs e)
        {
            var panel = sender as Panel;
            var item = panel.NamingContainer as RepeaterItem;
            panel.Attributes.Add("QuestionId", (item.DataItem as Question).Id.ToString());
        }

        private void Viewer_DataBinding(object sender, EventArgs e)
        {
            var viewer = sender as QuestionViewer;
            var item = viewer.NamingContainer as RepeaterItem;
            viewer.Question = item.DataItem as Question;
        }

        #endregion
    }
}