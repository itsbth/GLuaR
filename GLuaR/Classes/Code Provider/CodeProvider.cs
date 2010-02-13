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
using System.IO;
using System.Windows.Forms;

namespace GLuaR
{
    /// <summary>
    /// Provides code completion information and access to the code database
    /// </summary>
    public class CodeProvider
    {
        /// <summary>
        /// A list of libraries defined by this database
        /// </summary>
        public List<Library> Libraries;
        /// <summary>
        /// A list of overrides defined by this database
        /// </summary>
        public List<Override> Overrides;
        /// <summary>
        /// A list of keywords defined by this database
        /// </summary>
        public List<string> Keywords;

        /// <summary>
        /// Initializes a new CodeProvider class
        /// </summary>
        [Obsolete("Use CodeProvider.Load instead", false)]
        public CodeProvider()
        {
            Libraries = new List<Library>();
        }

        /// <summary>
        /// Checks if a certain string is a library
        /// </summary>
        /// <param name="lib">The name of the library</param>
        /// <returns>True if it's valid, otherwise false</returns>
        public bool IsLibrary( string lib )
        {
            if ( lib == "global" )
                return false;

            for ( int x = 0 ; x < Libraries.Count ; x++ )
            {
                if ( Libraries[x].Name == lib )
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Returns a list of members of a library
        /// </summary>
        /// <param name="from">The library to get the members of</param>
        /// <returns>An array of member objects</returns>
        public Member[] GetMembers( string from )
        {
            for ( int x = 0 ; x < Libraries.Count ; x++ )
            {
                if ( Libraries[x].Name == from )
                    return Libraries[x].Members.ToArray();
            }
            return new Member[] { };
        }

        /// <summary>
        /// Returns a list of functions in a library
        /// </summary>
        /// <param name="lib">The library to get a list of</param>
        /// <returns>An array of function objects</returns>
        public Function[] GetFunctions( string lib )
        {
            List<Function> funcs = new List<Function>();
            for ( int x = 0 ; x < Libraries.Count ; x++ )
            {
                if ( Libraries[x].Name == lib )
                {
                    for ( int y = 0 ; y < Libraries[x].Members.Count ; y++ )
                    {
                        if ( Libraries[x].Members[y] is Function )
                            funcs.Add( (Function)Libraries[x].Members[y] );
                    }
                }
            }
            return funcs.ToArray();
        }

        /// <summary>
        /// Returns a list of properties in a library
        /// </summary>
        /// <param name="lib">The library to get a list of</param>
        /// <returns>An array of property objects</returns>
        public Property[] GetProperties( string lib )
        {
            List<Property> props = new List<Property>();
            for ( int x = 0 ; x < Libraries.Count ; x++ )
            {
                if ( Libraries[x].Name == lib )
                {
                    for ( int y = 0 ; y < Libraries[x].Members.Count ; y++ )
                    {
                        if ( Libraries[x].Members[y] is Property )
                            props.Add( (Property)Libraries[x].Members[y] );
                    }
                }
            }
            return props.ToArray();
        }

        /// <summary>
        /// Returns a single function from a given library
        /// </summary>
        /// <param name="lib">The library to search. Pass "" to search globals</param>
        /// <param name="function">The function to search for</param>
        /// <returns>A function object on success, null on failure</returns>
        public Function GetFunction( string lib, string function )
        {
            if ( lib == "" )
            {
                Function[] func = GetFunctions( "globals" );
                for ( int x = 0 ; x < func.Length ; x++ )
                {
                    if ( func[x].Name == function )
                        return func[x];
                }
                return null;
            }
            for ( int x = 0 ; x < Libraries.Count ; x++ )
            {
                if ( Libraries[x].Name == lib )
                {
                    foreach ( Function func in Libraries[x].Members )
                    {
                        if ( func.Name == function )
                            return func;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Loads a code database
        /// </summary>
        /// <param name="file">The filename to load</param>
        /// <returns>Returns a code provider object on success, null on failure</returns>
        public static CodeProvider Load( string file )
        {
            FileStream fs = null;
            XmlSerializer xs = null;
            CodeProvider cp = null;

            try
            {
                fs = File.Open( file, FileMode.Open, FileAccess.Read, FileShare.Read );
            }
            catch ( Exception ex )
            {
                new ErrorDialog( ex ).ShowDialog();
                return null;
            }

            try
            {
                xs = new XmlSerializer( typeof( CodeProvider ) );
            }
            catch ( Exception ex )
            {
                new ErrorDialog( ex ).ShowDialog();
                fs.Close();
                return null;
            }

            try
            {
                cp = (CodeProvider)xs.Deserialize( fs );
            }
            catch ( Exception ex )
            {
                new ErrorDialog( ex ).ShowDialog();
                fs.Close();
                return null;
            }

            foreach ( Library lib in cp.Libraries )
            {
                foreach ( Member memb in lib.Members )
                {
                    memb.Library = lib;
                }
            }
            return cp;
        }
        /// <summary>
        /// Loads a code database
        /// </summary>
        /// <param name="file">The filename to load</param>
        /// <param name="suppressErrors">true to suppress error dialogs, otherwise false</param>
        /// <returns>Returns a code provider object on success, null on failure</returns>
        public static CodeProvider Load( string file, bool suppressErrors )
        {
            FileStream fs = null;
            XmlSerializer xs = null;
            CodeProvider cp = null;

            try
            {
                fs = File.Open( file, FileMode.Open, FileAccess.Read, FileShare.Read );
            }
            catch ( Exception ex )
            {
                if ( !suppressErrors )
                    new ErrorDialog( ex ).ShowDialog();
                return null;
            }

            try
            {
                xs = new XmlSerializer( typeof( CodeProvider ) );
            }
            catch ( Exception ex )
            {
                if ( !suppressErrors )
                    new ErrorDialog( ex ).ShowDialog();
                fs.Close();
                return null;
            }

            try
            {
                cp = ( CodeProvider )xs.Deserialize( fs );
            }
            catch ( Exception ex )
            {
                if ( !suppressErrors )
                    new ErrorDialog( ex ).ShowDialog();
                fs.Close();
                return null;
            }

            foreach ( Library lib in cp.Libraries )
            {
                foreach ( Member memb in lib.Members )
                {
                    memb.Library = lib;
                }
            }
            return cp;
        }

        // Shouldn't be used
        [Obsolete("Should not be called from user code", true)]
        private static void Save( string file, CodeProvider code )
        {
            FileStream fs = File.Create( file );
            XmlSerializer xs = new XmlSerializer( typeof( CodeProvider ) );
            xs.Serialize( fs, code );
            fs.Close();
        }
    }
}
