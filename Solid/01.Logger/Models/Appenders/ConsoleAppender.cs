using System;

using _01.Logger.Common;
using _01.Logger.Models.Contracts;
using _01.Logger.Models.Enumerations;

namespace _01.Logger.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private int messegesAppend;

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
                message.ToString(),
                level.ToString());

        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString()}, Messages appended: {this.messegesAppend}";
        }
    }
}
