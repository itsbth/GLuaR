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
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using GLuaR.Classes.Workspace;
using GLuaR.Windows.Dialogs;

namespace GLuaR.Classes
{
    /// <summary>
    /// Represents a project as a collection of options and files
    /// </summary>
    public class Project
    {
        /// <summary>
        /// The author's email
        /// </summary>
        public string AuthorEmail;

        /// <summary>
        /// The author's name
        /// </summary>
        public string AuthorName;

        /// <summary>
        /// The author's website
        /// </summary>
        public string AuthorWebsite;

        /// <summary>
        /// A description of the project
        /// </summary>
        public string Description;

        /// <summary>
        /// A list of files in the project
        /// </summary>
        public List<OpenedFile> Files;

        /// <summary>
        /// A list of folders in the project
        /// </summary>
        public List<Folder> Folders;

        /// <summary>
        /// The fullname of the project
        /// </summary>
        [XmlIgnore] public string FullName;

        /// <summary>
        /// Determines if the project should be hidden in garry's mod
        /// </summary>
        public bool HideEntry;

        /// <summary>
        /// The name of the project
        /// </summary>
        public string Name;

        /// <summary>
        /// The relative path to the project
        /// </summary>
        [XmlIgnore] public string Path;

        /// <summary>
        /// A list of GCF requirements, used when generating an info file
        /// </summary>
        public List<Requirement> Requirements;

        /// <summary>
        /// Determines if this project is saved, should use Project.IsProjectSaved()
        /// </summary>
        [XmlIgnore] public bool Saved;

        /// <summary>
        /// A list of tasks related to this project (TODO)
        /// </summary>
        public List<Task> Tasks;

        /// <summary>
        /// The project type, such as addon or gamemode
        /// </summary>
        public ProjectType Type;

        /// <summary>
        /// The last update of the project
        /// </summary>
        public string Update;

        /// <summary>
        /// The version of the project
        /// </summary>
        public string Version;

        /// <summary>
        /// Initializes a new project class
        /// </summary>
        public Project()
        {
            Requirements = new List<Requirement>();
            Files = new List<OpenedFile>();
            Folders = new List<Folder>();
            Tasks = new List<Task>();
        }

        /// <summary>
        /// Determines if the project and the files inside the project are saved
        /// </summary>
        /// <returns>True if everything is saved, otherwise false</returns>
        public bool IsProjectSaved()
        {
            foreach (OpenedFile pf in Files)
            {
                if (!pf.Saved)
                    return false;
            }
            foreach (Folder f in Folders)
            {
                if (!f.AllFilesSaved())
                    return false;
            }
            return Saved;
        }

        /// <summary>
        /// Saves the project and all files inside it
        /// </summary>
        public void Save()
        {
            SaveProject(FullName, this);
            Saved = true;

            foreach (Folder f in Folders)
            {
                f.Save();
            }
            foreach (OpenedFile pf in Files)
            {
                pf.Save();
            }
        }

        /// <summary>
        /// Displays the project dialog and generates a new project object
        /// </summary>
        /// <returns>A new project object</returns>
        public static Project NewProject()
        {
            var pd = new ProjectDialog();

            if (pd.ShowDialog() != DialogResult.OK)
                return null;

            if (
                File.Exists(pd.ProjectPath + "\\" +
                            (pd.ProjectName.EndsWith(".glu") ? pd.ProjectName : pd.ProjectName + ".glu")))
            {
                Util.ShowError("Error! The project already exists!");
                return NewProject();
            }

            if (!Directory.Exists(pd.ProjectPath))
            {
                DirectoryInfo directory = Directory.CreateDirectory(pd.ProjectPath);

                if (!directory.Exists)
                {
                    Util.ShowError("Invalid project directory");
                    return NewProject();
                }
            }

            return new Project
                       {
                           Name = pd.ProjectName,
                           Description = pd.ProjectDescription,
                           Type = pd.ProjectType,
                           Version = "",
                           Update = "",
                           AuthorName = "",
                           AuthorEmail = "",
                           AuthorWebsite = "",
                           HideEntry = false,
                           Saved = false,
                           Path = pd.ProjectPath,
                           FullName = pd.ProjectPath + "\\" +
                                      (pd.ProjectName.EndsWith(".glu") ? pd.ProjectName : pd.ProjectName + ".glu")
                       };
        }

        /// <summary>
        /// Loads a project from a file
        /// </summary>
        /// <param name="filename">The filename to load</param>
        /// <returns>A project object on success, null on failure</returns>
        public static Project LoadProject(string filename)
        {
            XmlSerializer xs;
            FileStream fs;
            Project proj;

            //try
            {
                xs = new XmlSerializer(typeof (Project));
            }
            //catch ( Exception ex )
            //{
            //    new ErrorDialog( ex ).ShowDialog();
            //    return null;
            //}

            try
            {
                fs = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            catch (Exception ex)
            {
                new ErrorDialog(ex).ShowDialog();
                return null;
            }

            try
            {
                proj = (Project) xs.Deserialize(fs);
            }
            catch (Exception ex)
            {
                new ErrorDialog(ex).ShowDialog();
                fs.Close();
                return null;
            }

            fs.Close();

            return proj;
        }

        /// <summary>
        /// Saves a project to a file
        /// </summary>
        /// <param name="filename">The filename to save the project as</param>
        /// <param name="proj">The project to save</param>
        public static void SaveProject(string filename, Project proj)
        {
            XmlSerializer xs;
            FileStream fs;

            try
            {
                xs = new XmlSerializer(typeof (Project));
            }
            catch (Exception ex)
            {
                new ErrorDialog(ex).ShowDialog();
                return;
            }

            try
            {
                fs = File.Create(filename);
            }
            catch (Exception ex)
            {
                new ErrorDialog(ex).ShowDialog();
                return;
            }
#if !DEBUG
            try
            {
#endif
            xs.Serialize(fs, proj);
#if !DEBUG 
            }
            catch ( Exception ex )
            {
                new ErrorDialog( ex ).ShowDialog();
                fs.Close();
                return;
            }
#endif

            fs.Close();
        }
    }
}