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
namespace GLuaR.Classes.Templates
{
    /// <summary>
    /// Represents an empty project template
    /// </summary>
    public class EmptyProjectTemplate : ProjectTemplate
    {
        /// <summary>
        /// Initializes a new project template
        /// </summary>
        public EmptyProjectTemplate()
        {
            Name = "Empty Project";
            Description = "An empty project.";

            DefaultName = "GLua Project 1";

            AllowType = true; // allow the user to change the project type
            ForcedType = ProjectType.Addon; // this doesn't matter because AllowType is true

            CodeFiles = new ProjectCode[0]; // we don't have any codefiles yet
        }
    }
}