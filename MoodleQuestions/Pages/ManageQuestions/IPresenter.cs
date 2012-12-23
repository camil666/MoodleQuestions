using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace MoodleQuestions.Pages.ManageQuestions
{
    public interface IPresenter
    {
        #region Methods

        XElement GenerateXml();

        #endregion
    }
}
