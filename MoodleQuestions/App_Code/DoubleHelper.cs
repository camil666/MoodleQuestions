using System;
using System.Globalization;

namespace MoodleQuestions
{
    public static class DoubleHelper
    {
        #region Methods

        public static double Parse(string value)
        {
            double result;

            if (!double.TryParse(value, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture, out result) &&
                !double.TryParse(value, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out result) &&
                !double.TryParse(value, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        #endregion
    }
}