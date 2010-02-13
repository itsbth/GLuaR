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
using System.Windows.Forms;

namespace GLuaR
{
    // various defines which couldn't be put elsewhere are here

    /// <summary>
    /// Determines the type of the project
    /// </summary>
    public enum ProjectType : int
    {
        Addon               = 0,
        Gamemode            = 1,
    }
    /// <summary>
    /// Determines the priority of a task
    /// </summary>
    public enum TaskPriority : int
    {
        High                = 0,
        Normal              = 1,
        Low                 = 2,
    }
    /// <summary>
    /// Determines the type of tab a special tab is
    /// </summary>
    public enum TabType : int
    {
        ObjectBrowser       = 0 ,
        ProjectInfo         = 1,
    }
    /// <summary>
    /// Represents various version types used by the update checker
    /// </summary>
    public enum VersionType : int
    {
        Alpha               = 0,
        Beta                = 1,
        ReleaseCandidate    = 2,
        Release             = 3,
    }
    /// <summary>
    /// The type of autocomplete, used by settings
    /// </summary>
    public enum AutoCompleteType : int
    {
        Restrictive         = 0,
        AlwaysOn            = 1,
    }
}