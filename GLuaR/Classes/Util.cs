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
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GLuaR
{
    /// <summary>
    /// Utility class for various things
    /// </summary>
    public class Util
    {
        // consts
        public const uint MB_ICONHAND = 0x00000010;
        public const uint MB_ICONQUESTION = 0x00000020;
        public const uint MB_ICONEXCLAMATION = 0x00000030;
        public const uint MB_ICONASTERISK = 0x00000040;

        public const uint MB_USERICON = 0x00000080;
        public const uint MB_ICONWARNING = MB_ICONEXCLAMATION;
        public const uint MB_ICONERROR = MB_ICONHAND;

        public const uint MB_ICONINFORMATION = MB_ICONASTERISK;
        public const uint MB_ICONSTOP = MB_ICONHAND;

        public const uint WM_USER = 0x0400;
        public const uint WM_GLUA_OPENFILE = WM_USER + 1;
        public const uint WM_GLUA_END = WM_USER + 2;
        public const uint WM_GLUA_START = WM_USER + 3;

        // messageboxes
        public static DialogResult ShowError(string msg)
        {
            return MessageBox.Show(msg, "GLuaR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowQuestion(string msg)
        {
            return MessageBox.Show(msg, "GLuaR", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }


        // winapi calls
        [DllImport("user32.dll")]
        public static extern bool MessageBeep( // used for custom dialog boxes
            uint uType // sound type
            );

        [DllImport("shell32.dll")]
        public static extern IntPtr ShellExecute( // glua doesn't use ShellExecute, this was for an issue someone experienced
            IntPtr hwnd, // handle to parent window
            string lpOperation, // pointer to string that specifies operation to perform
            string lpFile, // pointer to filename or folder name string
            string lpParameters, // pointer to string that specifies executable-file parameters 
            string lpDirectory, // pointer to string that specifies default directory
            int nShowCmd // whether file is shown when opened
            );

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow( // used to find other glua instances
            string lpClassName, // pointer to class name
            string lpWindowName // pointer to window name
            );

        [DllImport("user32.dll")]
        public static extern int SendMessage( // used to send messages to other instances
            IntPtr hWnd, // handle of destination window
            uint Msg, // message to send
            uint wParam, // first message parameter
            uint lParam // second message parameter
            );
    }
}