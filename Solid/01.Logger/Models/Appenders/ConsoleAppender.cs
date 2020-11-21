using System;

using _01.Logger.Common;
using _01.Logger.IOManegment;
using _01.Logger.Models.Contracts;
using _01.Logger.Models.Enumerations;
using _01.Logger.IOManegment.Contracts;

namespace _01.Logger.Models.Appenders
{
    public class ConsoleAppender : Appender
    {
        private readonly IWriter writer;

        public ConsoleAppender(ILayout layout , Level level)
            :base(layout , level)
        {
            this.writer = new ConsoleWriter();
        }

        public override void Append(IError error)
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
    }
}
