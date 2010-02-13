/*

    This file is part of GLua

    GLua Development Environment
    Copyright (C) 2007 VoiDeD

    GLua is free software; you can redistribute it and/or modify
    it under the terms of the GNU Lesser General Public License as published by
    the Free Software Foundation; either version 3 of the License, or
    (at your option) any later version.

    GLua is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.

*/

using System.IO;
using System.Xml.Serialization;

namespace GLuaR.Classes.Templates
{
    /// <summary>
    /// Represents the base file template
    /// </summary>
    public class Template
    {
        /// <summary>
        /// ID
        /// </summary>
        [XmlElement] public string ID;

        /// <summary>
        /// Any code in the file
        /// </summary>
        [XmlElement] public string Code;

        /// <summary>
        /// The default filename that should be displayed
        /// </summary>
        [XmlElement] public string DefaultFileName;

        /// <summary>
        /// File description
        /// </summary>
        [XmlElement] public string Description;

        /// <summary>
        /// The name of the file
        /// </summary>
        [XmlElement] public string Name;

        /// <summary>
        /// Visible in list
        /// </summary>
        [XmlElement] public bool Visible;

        public static Template Load(Stream fileStream)
        {
            return (Template) new XmlSerializer(typeof (Template)).Deserialize(fileStream);
        }
    }
}