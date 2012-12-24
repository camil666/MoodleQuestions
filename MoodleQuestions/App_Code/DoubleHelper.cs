using System;
using System.Globalization;

namespace MoodleQuestions
{
    public static class DoubleHelper
    {
        #region Methods

        /// <summary>
        /// Parses the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Parsed double.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when parsing was not successful.</exception>
        public static double Parse(string value)
        {
            double result;

            if (!double.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out result) &&
                !double.TryParse(value, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out result) &&
                !double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        #endregion
    }
}