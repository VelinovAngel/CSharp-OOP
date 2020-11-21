using System;
using _01.Logger.Models.Contracts;
using _01.Logger.Models.Enumerations;

namespace _01.Logger.Models.Appenders
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout , Level level, IFile file)
        {
            this.Layout = layout;
            this.Level = level;
            this.File = file;
        }

        public ILayout Layout { get; }

        public Level Level { get; }

        public IFile File { get;}

        public void Append(IError error)
        {
            throw new NotImplementedException();
        }
    }
}
