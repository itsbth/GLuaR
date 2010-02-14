using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace GLuaR.Classes.Snippet
{
    class Snippet
    {
        /// <summary>
        /// ID
        /// </summary>
        [XmlElement] public string ID;

        /// <summary>
        /// Actual code
        /// </summary>
        [XmlElement] public string Code;

    }
}
