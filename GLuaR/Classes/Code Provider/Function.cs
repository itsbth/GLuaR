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
    /// Represents a function inside a code database
    /// </summary>
    public class Function : Member
    {
        /// <summary>
        /// The return type of this function
        /// </summary>
        [XmlAttribute]
        public string Return;

        /// <summary>
        /// The name of this function
        /// </summary>
        [XmlAttribute]
        public string Name;
        
        /// <summary>
        /// Text representation of the parameters
        /// </summary>
        [XmlAttribute]
        public string Params;

        /// <summary>
        /// Description of this function
        /// </summary>
        [XmlAttribute]
        public string Description;

        /// <summary>
        /// The type of this function
        /// </summary>
        [XmlAttribute]
        public string Type; // only "SERVER", "CLIENT", "SHARED"

        /// <summary>
        /// A list of strongly defined parameters for this function
        /// </summary>
        public List<Parameter> Parameters;

        public Function()
        {
            Parameters = new List<Parameter>();
        }
    }
}
