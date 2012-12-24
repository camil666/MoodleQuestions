using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoodleQuestions.Pages.ManageQuestions
{
    public class SelectionTemplate : ITemplate
    {
        #region Methods

        /// <summary>
        /// When implemented by a class, defines the <see cref="T:System.Web.UI.Control" /> object that child controls and templates belong to.
        /// These child controls are in turn defined within an inline template.
        /// </summary>
        /// <param name="container">The <see cref="T:System.Web.UI.Control" /> object to contain the instances of controls from the inline template.</param>
        public void InstantiateIn(Control container)
        {
            var checkBox = new CheckBox();
            container.Controls.Add(checkBox);
        }

        #endregion
    }
}