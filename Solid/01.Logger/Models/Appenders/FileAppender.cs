using System;

using _01.Logger.IOManegment;
using _01.Logger.Models.Contracts;
using _01.Logger.Models.Enumerations;
using _01.Logger.IOManegment.Contracts;

namespace _01.Logger.Models.Appenders
{
    public class FileAppender : Appender
    {
        private readonly IWriter writer;

        public FileAppender(ILayout layout, Level level, IFile file)
            : base(layout, level)
        {
            this.File = file;

            this.writer = new FileWriter(this.File.Path);
        }

        public IFile File { get; }

        public override void Append(IError error)
        {
            string formattedMessage = this.File.Write(this.Layout, error);

            this.writer.WriteLine(formattedMessage);
            this.messegesAppend++; 
        }

        public override string ToString()
        {
            return base.ToString() + $", File size {this.File.Size}";
        }

    }
}
