/*

    This file is part of GLuaR

    GLuaR Development Environment
    Copyright (C) 2007 "Marine" (FPMarine@googlemail.com).
    Portions by "VoiDeD".

    GLuaR is free software; you can redistribute it and/or modify
    it under the terms of the GNU Lesser General Public License as published by
    the Free Software Foundation; either version 3 of the License, or
    (at your option) any later version.

    GLuaR is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.

*/

using System;
using System.Collections.Generic;
using System.Text;

namespace GLuaR.Classes.Workspace
{
    /// <summary>
    /// Represents an attribute used for setting tips
    /// </summary>
    [AttributeUsage( AttributeTargets.Field, Inherited = false, AllowMultiple = true )]
    public class SettingAttribute : Attribute
    {
        /// <summary>
        /// The name of the setting
        /// </summary>
        public string Name;

        /// <summary>
        /// A list of options available for the setting, must be same length as Descriptions
        /// </summary>
        public string[] Options;
        /// <summary>
        /// A list of descriptions available for the setting, must be same length as Options
        /// </summary>
        public string[] Descriptions;

        public SettingAttribute()
        {
        }
    }
}
