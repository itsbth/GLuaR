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
using System.IO;
using System.Windows.Forms;
using GLuaR.Windows;

namespace GLuaR
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //try
            //{
            if (args.Length > 0)
            {
                // huge class name 
                IntPtr hwnd = Util.FindWindow("WindowsForms10.Window.8.app.0.378734a", "GLua");
                if (hwnd != IntPtr.Zero) // we have a valid handle
                {
                    FileInfo fi;
                    try
                    {
                        fi = new FileInfo(args[0]);
                        if (!fi.Exists)
                            return;
                    }
                    catch
                    {
                        // invalid file, we return and don't do anything
                        return;
                    }
                    switch (fi.Extension)
                    {
                        case ".lua":
                            {
                                /* 
                             * message format is like this:
                             * 
                             * <START> WM_GLUA_START
                             * "f" WM_GLUA_OPENFILE
                             * "i" WM_GLUA_OPENFILE
                             * "l" WM_GLUA_OPENFILE
                             * "e" WM_GLUA_OPENFILE
                             * "." WM_GLUA_OPENFILE
                             * "l" WM_GLUA_OPENFILE
                             * "u" WM_GLUA_OPENFILE
                             * "a" WM_GLUA_OPENFILE
                             * <END> WM_GLUA_END
                             * 
                             * Marshal.Copy was failing on me so I decided on this method
                             * this message is handled by the main window, look in the WndProc
                            */
                                Util.SendMessage(hwnd, Util.WM_GLUA_START, 0, 0);
                                char[] file = args[0].ToCharArray();
                                for (int x = 0; x < file.Length; x++)
                                {
                                    Util.SendMessage(hwnd, Util.WM_GLUA_OPENFILE, file[x], 0);
                                }
                                Util.SendMessage(hwnd, Util.WM_GLUA_END, 0, 0);
                            }
                            break;
                        case ".glu":
                            Application.Run(new MainForm(args[0]));
                            break;
                    }
                }
                else // glua isn't open yet
                {
                    // should actually start now
                    Application.Run(new MainForm(args[0]));
                }
            }
            else
                // no arguments, start glua normally
                Application.Run(new MainForm());
            //}
            //catch (Exception ex)
            //{
            //    if (System.Diagnostics.Debugger.IsAttached)
            //        throw ex;
            //    else
            //        new ErrorDialog(ex).ShowDialog();
            //}
        }
    }
}