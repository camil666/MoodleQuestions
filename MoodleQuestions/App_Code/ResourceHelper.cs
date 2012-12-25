using System.Web;

namespace MoodleQuestions
{
    public static class ResourceHelper
    {
        #region Constants

        private static string ResourceFileName = "Strings";

        #endregion

        #region Methods

        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <param name="resourceName">Name of the resource.</param>
        /// <returns>Resource string.</returns>
        public static string GetString(string resourceName)
        {
            return HttpContext.GetGlobalResourceObject(ResourceFileName, resourceName).ToString();
        }

        #endregion
    }
}