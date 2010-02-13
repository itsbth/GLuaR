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
using System.IO;

namespace GLuaR.Classes
{
    /// <summary>
    /// Utility class for generating info files
    /// </summary>
    public static class InfoGenerator
    {
        /// <summary>
        /// Generates an info file for a specific project
        /// </summary>
        /// <param name="filename">The filename to save the info file as</param>
        /// <param name="proj">The project to generate a file for</param>
        public static void GenerateInfo(string filename, Project proj)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                fs = File.Create(filename);
            }
            catch (Exception ex)
            {
                new ErrorDialog(ex).ShowDialog();
            }

            try
            {
                sw = new StreamWriter(fs);
            }
            catch (Exception ex)
            {
                new ErrorDialog(ex).ShowDialog();
            }

            switch (proj.Type)
            {
                case ProjectType.Addon:
                    WriteAddonInfo(sw, proj);
                    break;
                case ProjectType.Gamemode:
                    WriteGamemodeInfo(sw, proj);
                    break;
            }
        }

        // generates addon info for a project
        private static void WriteAddonInfo(TextWriter writer, Project proj)
        {
            writer.WriteLine("\"AddonInfo\"");
            writer.WriteLine("{");
            writer.WriteLine("\t\"name\"\t\t\"" + proj.Name + "\"");
            writer.WriteLine("\t\"version\"\t\"" + proj.Version + "\"");
            writer.WriteLine("\t\"update\"\t\"" + proj.Update + "\"");
            writer.WriteLine("\t\"author_name\"\t\"" + proj.AuthorName + "\"");
            writer.WriteLine("\t\"author_email\"\t\"" + proj.AuthorEmail + "\"");
            writer.WriteLine("\t\"author_url\"\t\"" + proj.AuthorWebsite + "\"");
            writer.WriteLine();
            writer.WriteLine("\t\"info\"\t\t\"" + proj.Description + "\"");
            writer.WriteLine();
            writer.WriteLine("\t// Won't be active unless the following GCFs are available and");
            writer.WriteLine("\t// are mounted");
            writer.WriteLine("\t\"GCFRequires\"");
            writer.WriteLine("\t{");
            for (int x = 0; x < proj.Requirements.Count; x++)
            {
                writer.WriteLine("\t\t\"" + x + "\"\t\t\"" + proj.Requirements[x].AppID + "\"");
            }
            writer.WriteLine("\t}");
            writer.WriteLine("}");

            writer.Close();
        }

        // generates gamemode info for a project
        private static void WriteGamemodeInfo(TextWriter writer, Project proj)
        {
            writer.WriteLine("\"Gamemode\"");
            writer.WriteLine("{");
            writer.WriteLine("\t\"name\"\t\t\"" + proj.Name + "\"");
            writer.WriteLine("\t\"version\"\t\"" + proj.Version + "\"");
            writer.WriteLine();
            writer.WriteLine("\t\"author_name\"\t\"" + proj.AuthorName + "\"");
            writer.WriteLine("\t\"author_email\"\t\"" + proj.AuthorEmail + "\"");
            writer.WriteLine("\t\"author_url\"\t\"" + proj.AuthorWebsite + "\"");
            writer.WriteLine();
            writer.WriteLine("\t\"info\"\t\t\"" + proj.Description + "\"");
            writer.WriteLine();
            writer.WriteLine("\t// Setting this to 0 will hide the gamemode entry");
            writer.WriteLine("\t\"hide\"\t\t\"" + (proj.HideEntry ? 1 : 0) + "\"");
            writer.WriteLine("}");

            writer.Close();
        }
    }
}