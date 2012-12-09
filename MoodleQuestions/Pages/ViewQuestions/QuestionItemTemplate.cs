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
            var viewer = new QuestionViewer();
            viewer.DataBinding += Viewer_DataBinding;
            container.Controls.Add(viewer);
        }

        void Viewer_DataBinding(object sender, EventArgs e)
        {
            var viewer = sender as QuestionViewer;
            var item = viewer.NamingContainer as RepeaterItem;
            viewer.Question = item.DataItem as Question;
        }

        #endregion
    }
}