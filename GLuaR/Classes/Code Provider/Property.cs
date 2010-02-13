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
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace GLuaR
{
    /// <summary>
    /// Defines a property used in libraries
    /// </summary>
    public class Property : Member
    {
        /// <summary>
        /// The data type of the property
        /// </summary>
        [XmlAttribute]
        public string DataType;

        /// <summary>
        /// The name of the property
        /// </summary>
        [XmlAttribute]
        public string Name;

        /// <summary>
        /// A description of the property
        /// </summary>
        [XmlAttribute]
        public string Description;

        /// <summary>
        /// Where the property is available in code: "SERVER", "CLIENT", etc
        /// </summary>
        [XmlAttribute]
        public string Type; // "SERVER", "CLIENT", "SHARED"
    }
}
