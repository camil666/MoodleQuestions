using System.Xml.Linq;

namespace MoodleQuestions.Pages.ManageQuestions
{
    public interface IPresenter
    {
        #region Methods

        /// <summary>
        /// Generates the XML.
        /// </summary>
        /// <returns>Generated xml.</returns>
        XElement GenerateXml();

        #endregion
    }
}
