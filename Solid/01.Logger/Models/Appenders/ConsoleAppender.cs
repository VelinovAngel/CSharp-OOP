using System;

using _01.Logger.Common;
using _01.Logger.IOManegment;
using _01.Logger.Models.Contracts;
using _01.Logger.Models.Enumerations;
using _01.Logger.IOManegment.Contracts;

namespace _01.Logger.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private int messegesAppend;
        private readonly IWriter writer;

        private ConsoleAppender()
        {
            this.writer = new ConsoleWriter();
        }

        public ConsoleAppender(ILayout layout , Level level)
        {
            this.Layout = layout;
            this.Level = Level;
        }

        public ILayout Layout { get; }

        public Level Level { get; }

        public void Append(IError error)
        {
            string format = this. Layout.Format;

            DateTime dateTime = error.DateTime;

            string message = error.Message;

            Level level = error.Level;

            string formattedString = String.Format(format,
                dateTime.ToString(GlobalConstans.DateTimeFormat),
                level.ToString(),
                message);

            this.writer.WriteLine(formattedString);
            this.messegesAppend++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString()}, Messages appended: {this.messegesAppend}";
        }
    }
}
