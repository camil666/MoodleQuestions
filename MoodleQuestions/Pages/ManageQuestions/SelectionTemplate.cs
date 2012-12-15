using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoodleQuestions.Pages.ManageQuestions
{
    public class SelectionTemplate : ITemplate
    {
        #region Methods

        public void InstantiateIn(Control container)
        {
            var checkBox = new CheckBox();
            container.Controls.Add(checkBox);
        }

        #endregion
    }
}