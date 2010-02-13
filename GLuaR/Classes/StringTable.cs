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

/*
 * 
 * 
 * 
 * PLEASE NOTE!!! DO NOT USE THIS FOR ANY NEW STRINGS. WE ARE NOT PROVIDING LOCALIZATION SUPPORT IN THIS (UNLESS
 *  YOU CAN CODE IT IN BETTER TO WORK WITH THE DESIGNERS) SO PLEASE HARDCODE STRINGS! THIS IS HERE FOR BACKWARDS COMPATIBILITY!
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace GLuaR
{
    /// <summary>
    /// Utility class used for localization
    /// </summary>
    // This was going to be a supported feature
    // But the C# Express form designer happens to change property references from other classes to exact text
    // So as a value was copied from the string table to the designer, it stayed with the form and didn't get the string table version
    // Currently this is one large mess with some forms using stringtable values and others using plain text
    // This would be a real hassle to fix, so I dropped localization support
    
    // There are however, some used internal strings down near the bottom of the class
    // These are used for various things
    public class StringTable
    {
        // buttons
        public const string BTNDelete = "Delete";
        public const string BTNRemove = "Remove";
        public const string BTNCancel = "Cancel";
        public const string BTNOk = "Ok";
        public const string BTNClose = "Close";
        public const string BTNAdd = "Add";
        public const string BTNBrowse = "Browse...";
        public const string BTNSave = "Save";

        // menus
        public const string MNUFile = "&File";
        public const string MNUNewProject = "&New Project...";
        public const string MNUOpenProject = "Open &Project...";
        public const string MNUOpen = "&Open";
        public const string MNUClose = "&Close";
        public const string MNUCloseProject = "Close P&roject";
        public const string MNUSave = "&Save";
        public const string MNUSaveProject = "Save Pr&oject";
        public const string MNUExit = "E&xit";

        public const string MNUEdit = "&Edit";
        public const string MNUUndo = "&Undo";
        public const string MNURedo = "&Redo";
        public const string MNUCut = "Cu&t";
        public const string MNUCopy = "&Copy";
        public const string MNUPaste = "&Paste";
        public const string MNUDelete = "&Delete";
        public const string MNUSelectAll = "Select &All";
        public const string MNUFindAndReplace = "&Find And Replace";
        public const string MNUFind = "&Find";
        public const string MNUReplace = "&Replace";

        public const string MNUView = "&View";
        public const string MNUProjectExplorer = "Project &Explorer";
        public const string MNUObjectBrowser = "Object &Browser";
        public const string MNUTaskList = "&Task List";
        public const string MNUOutput = "&Output";

        public const string MNUProject = "&Project";
        public const string MNUNewItem = "Add Ne&w Item...";
        public const string MNUExistingItem = "Add Existin&g Item...";
        public const string MNUGenerateInfo = "Generate Info File";
        public const string MNUProjectProps = "P&roject Properties...";

        public const string MNUTools = "&Tools";
        public const string MNUCustomize = "&Customize";
        public const string MNUOptions = "&Options";
        public const string MNUPlugins = "Plu&gins...";
        public const string MNUCheckUpdates = "Check For &Updates...";

        public const string MNUHelp = "&Help";
        public const string MNULuaWiki = "Garry's Mod Lua Wiki";
        public const string MNULuaForum = "Facepunch - Lua Scripting";
        public const string MNUHome = "GLua Homepage";
        public const string MNUReportBug = "Report A Bug";
        public const string MNUAbout = "&About GLua...";

        // about dialog
        public const string AboutTitle = "About GLua";
        public const string AboutProduct = "GLua Development Environment";
        public const string AboutThanks = "Thanks to the following people:\r\n\r\nExileLord, for alpha testing and art.\r\n\r\nJefff, for internal help. Beta wouldn't have been possible without his help.\r\n\r\nBlade, Xera, Munk, Toaster, Proctoru2, Itsbth, and Orangutanz for beta testing.\r\n\r\nAnd last but certainly not least:\r\nTeam Garry, for a great game!";

        // error debugger dialog
        public const string ErrorTitle = "Exception!";
        public const string ErrorHeader = "It seems that our boat has a leak...\r\nError details are displayed below.\r\n\r\nYou can help by sending a bug report, or by emailing voided@glua.net.\r\nWhen sending the message, please include as much information as possible to help diagnose the problem.\r\nInformation such as what you were doing, any previous errors, and steps to recreate this error are all very, very useful!";
        public const string ErrorReport = "Report This Bug!";

        // file remove dialog
        public const string FRDMessage = "Do you want to permenantly delete '%FILE%', or just remove it from the project?";

        // gcf requirement dialog
        public const string GCFTitle = "Add GCF Requirement";
        public const string GCFSpecific = "Specific";
        public const string GCFCustom = "Custom";

        // new file dialog
        public const string NFDTitle = "Add New Item";
        public const string NFDHeader = "Templates:";
        public const string NFDInfo = "Name:";
        public const string NFDInstalledTemplates = "Installed Templates";
        public const string NFDCustomTemplates = "Custom Templates";

        // project dialog
        public const string PDTitle = "New Project";
        public const string PDLocation = "Location:";
        public const string PDDescription = "Description:";
        public const string PDType = "Type:";

        // rename dialog
        public const string RDMesage = "Renaming '%FILE%':";

        // object browser
        public const string OBTitle = "Object Browser";
        public const string OBDefaultSearch = "<Search>";
        public const string OBSearch = "Search";
        public const string OBClear = "Clear Search";

        // project properties
        public const string PPTitle = "Project Properties";
        public const string PPProjName = "Project Name:";
        public const string PPProjType = "Project Type:";
        public const string PPProjDesc = "Description:";
        public const string PPProjVer = "Version:";
        public const string PPProjUpd = "Update:";
        public const string PPAuthTitle = "Author Info";
        public const string PPAuthName = "Name:";
        public const string PPAuthSite = "Website:";
        public const string PPAuthEmail = "Email:";
        public const string PPHideEntry = "Hide Entry";
        public const string PPOverride = "Override";
        public const string PPGCFTitle = "Addon Specific";
        public const string PPGCFHeader = "GCF Requirements:";
        public const string PPGCFIndex = "Index";
        public const string PPGCFAppID = "Application ID";

        // main window
        public const string MWBetaInfoTitle = "Beta Info";
        public const string MWBetaInfo = "Welcome to the GLua Development Environment public beta.\r\nProtips:\r\n\r\nIf something is disabled, its probably not implemented yet. (Or you simply can't do it yet. i.e: Adding a file without a project opened)\r\nIf you have any questions, email voided@glua.net\r\nYou can close this window by hitting the small black 'X' in the top right";

        public const string MWProjExplorerTitle = "Project Explorer";
        public const string MWProjExplorerNewItem = "Add New Item (Ctrl+Shift+A)";
        public const string MWProjExplorerExistingItem = "Add Existing Item (Alt+Shift+A)";

        public const string MWTaskListTitle = "Task List";
        public const string MWTaskListAdd = "Create User Task";
        public const string MWTaskListComments = "Comments";
        public const string MWTaskListTasks = "User Tasks";
        public const string MWTaskListDescription = "Description";

        public const string MWOutputTitle = "Output";

        // main window quick strip
        public const string MWNewProject = "New Project (Ctrl+Shift+N)";
        public const string MWNewItem = "Add New Item (Ctrl+Shift+A)";
        public const string MWNewItemNewItem = "Add New Item...";
        public const string MWNewItemExistingItem = "Add Existing Item...";
        public const string MWOpenFile = "Open File (Ctrl+O)";
        public const string MWSaveFile = "Save File (Ctrl+S)";
        public const string MWSaveProject = "Save Project (Ctrl+Shift+S)";

        public const string MWCut = "Cut (Ctrl+X)";
        public const string MWCopy = "Copy (Ctrl+C)";
        public const string MWPaste = "Paste (Ctrl+V)";

        public const string MWUndo = "Undo (Ctrl+Z)";
        public const string MWRedo = "Redo (Ctrl+Y)";

        public const string MWFind = "Find (Ctrl+F)";

        public const string MWProjExplorer = "Project Explorer (Ctrl+Alt+E)";
        public const string MWObjectBrowser = "Object Browser (Ctrl+Alt+B)";
        public const string MWTaskList = "Task List (Ctrl+Alt+T)";
        public const string MWOutput = "Output (Ctrl+Alt+O)";

        // main window code strip
        public const string MWMembList = "Display Member List";
        public const string MWParamInfo = "Display Parameter Info";
        public const string MWWordComplete = "Display Word Completion (Ctrl+J)";

        public const string MWUnindent = "Decrease Indent";
        public const string MWIndent = "Increase Indent";

        public const string MWComment = "Comment Selected Line(s)";
        public const string MWUncomment = "Uncomment Selected Line(s)";

        // main window beta strip
        public const string MWReportBug = "Report A Bug!";

        // versioning
        public const string UnableToCheckForUpdates = "The GLua Auto-updater was unable to retrieve latest version information, please check that you are connected to the internet.";
        public const string UnableToCompareVerions = "Unable to compare the current version with any new versions.";

        // beta
        public const string UnableToValidate = "Could not validate your software copy.";
        public const string ValidationError = "An error has occured, please restart GLua to try to validate again.";
        public const string ValidationFailed = "\r\nValidation failed.\r\nDetails: ";
        public const string BetaQuestions = "\r\n\r\nFor any questions regarding the GLua beta, email 'voidedweasel@gmail.com'";
        public const string CouldNotContactHost = "Could not validate with remote host, please check that you are connected to the internet.";

        // code provider
        public const string UnableToLoadCodeDataBase = "Unable to load code provider database '%FILE%'.";
        public const string UnableToCreateCodeSerializer = "Unable to create code provider serializer.";
        public const string UnableToDeserializeCode = "Unable to deserialize code provider database.";

        // project serialization
        public const string UnableToCreateProject = "Unable to create project '%FILE%'.";
        public const string UnableToSerializeProject = "Unable to serialize project.";
        public const string UnableToDeserializeProject = "Unable to deserialize project file.";
        public const string UnableToCreateProjectSerializer = "Unable to create project serializer.";
        public const string UnableToOpenProject = "Unable to open project '%FILE$'.";


        // ui
        public const string FileAlreadyAdded = "The added file already exists.";
        public const string InvalidProjectName = "The project name you have chosen is invalid.";
        public const string InvalidFileName = "The filename you have chosen is invalid.";
        public const string InvalidDirectory = "The directory you have chosen is invalid.";
        public const string ProjectAlreadyExists = "The project name you have selected already exists.";
        public const string FileAlreadyExists = "The filename you have selected already exists.";
        public const string AppNotSelected = "Application ID was not selected.";
        public const string InvalidAppID = "Invalid Application ID.";
        public const string ProjectNotSaved = "Your project has not been saved, would you like to do so now?";
        public const string FileNotSaved = "The file '%FILE%' has not been saved, would you like to do so now?";
        public const string NewProject = "Creating a new project will close the current project. Continue?";
        public const string OpenProject = "Opening a new project will close the current project. Continue?";
        public const string ProjectFileLost = "The file '%FILE%' in the current project could not be found.";
        public const string ProjectFolderLost = "The folder '%FILE%' in the current project could not be found.";

        // internal
        public const string Title = "GLua";
        // the user agent to report when checking for updates or making other web requests
        public const string UserAgent = "Mozilla/4.0 (compatible; GLua; Windows; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        public const string IPCheckURL = "http://pcbin.net/voided/GLua/ipcheck.php"; // legacy, was for beta testing
        public const string UpdateCheckURL = "http://glua.net/versioncheck.php"; // TODO, this is not currently supported on glua.net, its more of a placeholder
        public const string BugReportURL = "http://glua.net/bugtrack/";
    }
}
