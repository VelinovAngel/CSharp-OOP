﻿using System;
using System.IO;
using System.Linq;

using _01.Logger.Common;
using _01.Logger.Models.Contracts;
using _01.Logger.Models.Enumerations;

namespace _01.Logger.Models.Files
{
    public class LogFile : IFile
    {
        private readonly IPathManager pathManager;

        public LogFile(IPathManager pathManager)
        {
            this.pathManager = pathManager;
            this.pathManager.EnsureDirectoryAndFileExists();
        }

        public string Path
            => this.pathManager.CurrentFilePath;

        public long Size
            => this.CalculateFileSize();

        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;

            DateTime dateTime = error.DateTime;

            string message = error.Message;

            Level level = error.Level;

            string formattedMessage = string.Format(format
                , dateTime.ToString(GlobalConstans.DateTimeFormat),
                level.ToString(),
                message.ToString());

            return formattedMessage;
        }

        private long CalculateFileSize()
        {
            string fileText = File.ReadAllText(this.Path);

            return fileText
                .ToCharArray()
                .Where(c => char.IsLetter(c))
                .Sum(c => c);
        }
    }
}
