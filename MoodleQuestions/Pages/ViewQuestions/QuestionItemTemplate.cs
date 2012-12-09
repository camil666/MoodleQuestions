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
        #region Methods

        public void InstantiateIn(Control container)
        {
            //var mainPanel = new Panel();
            //mainPanel.DataBinding += MainPanel_DataBinding;
            //container.Controls.Add(mainPanel);
            var checkBox = new CheckBox();
            checkBox.DataBinding += CheckBox_DataBinding;
            container.Controls.Add(checkBox);

            var viewer = new QuestionViewer();
            viewer.DataBinding += Viewer_DataBinding;
            container.Controls.Add(viewer);
        }

        private void CheckBox_DataBinding(object sender, EventArgs e)
        {
            var checkBox = sender as CheckBox;
            var item = checkBox.NamingContainer as RepeaterItem;
            checkBox.Attributes.Add("QuestionId", (item.DataItem as Question).Id.ToString());
        }

        //private void MainPanel_DataBinding(object sender, EventArgs e)
        //{
        //    var panel = sender as Panel;
        //    var item = panel.NamingContainer as RepeaterItem;
        //    panel.Attributes.Add("QuestionId", (item.DataItem as Question).Id.ToString());
        //}

        private void Viewer_DataBinding(object sender, EventArgs e)
        {
            var viewer = sender as QuestionViewer;
            var item = viewer.NamingContainer as RepeaterItem;
            viewer.Question = item.DataItem as Question;
        }

        #endregion
    }
}