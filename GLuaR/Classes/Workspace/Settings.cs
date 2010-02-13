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
using System.Xml.Serialization;
using System.IO;

namespace GLuaR.Classes.Workspace
{
    /// <summary>
    /// Manages various settings for GLua
    /// </summary>
    public class Settings
    {
        // put customizable settings here
        // settings should be in enum format with a [Setting] attribute attached for tips

        [Setting(
            Name = "AutoComplete", 
            Options = new string[] {
                "Restrictive",
                "Always On"
            },
            Descriptions = new string[] {
                "Auto-complete can only be activated by pressing 'Ctrl+J'",
                "Auto-complete will be activated as you type"
            })]
        public AutoCompleteType AutoComplete;

        /// <summary>
        /// Loads a settings object
        /// </summary>
        /// <param name="fname">The filename of the settings to load</param>
        /// <returns>A filled settings object</returns>
        public static Settings Load( string fname )
        {
            XmlSerializer xs = null;
            FileStream fs = null;
            Settings settings = null;

            try
            {
                xs = new XmlSerializer( typeof( Settings ) );
            }
            catch ( Exception ex )
            {
                new ErrorDialog( ex ).ShowDialog();
                return null;
            }

            try
            {
                fs = File.Open( fname, FileMode.Open, FileAccess.Read, FileShare.Read );
            }
            catch ( Exception ex )
            {
                new ErrorDialog( ex ).ShowDialog();
                return null;
            }

            try
            {
                settings = ( Settings )xs.Deserialize( fs );
            }
            catch ( Exception ex )
            {
                new ErrorDialog( ex ).ShowDialog();
                fs.Close();
                return null;
            }

            fs.Close();

            return settings;
        }
        /// <summary>
        /// Saves a settings object
        /// </summary>
        /// <param name="fname">The filename to save the settings as</param>
        /// <param name="settings">The settings object to save</param>
        public static void Save( string fname, Settings settings )
        {
            XmlSerializer xs = null;
            FileStream fs = null;

            try
            {
                xs = new XmlSerializer( typeof( Settings ) );
            }
            catch ( Exception ex )
            {
                new ErrorDialog( ex ).ShowDialog();
                return;
            }

            try
            {
                fs = File.Create( fname );
            }
            catch ( Exception ex )
            {
                new ErrorDialog( ex ).ShowDialog();
                return;
            }

            try
            {
                xs.Serialize( fs, settings );
            }
            catch (Exception ex)
            {
                new ErrorDialog( ex ).ShowDialog();
                fs.Close();
                return;
            }

            fs.Close();
        }
    }
}
