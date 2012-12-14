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
    public class QuestionItemTemplate : ITemplate
    {
        #region Properties

        public string CheckboxText { get; set; }

        #endregion

        #region Methods

        public void InstantiateIn(Control container)
        {
            var mainPanel = new Panel();
            mainPanel.DataBinding += MainPanel_DataBinding;
            container.Controls.Add(mainPanel);

            var checkBox = new CheckBox() { Text = CheckboxText, TextAlign = TextAlign.Right };
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