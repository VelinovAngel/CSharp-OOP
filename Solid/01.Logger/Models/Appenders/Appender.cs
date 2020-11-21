using _01.Logger.Models.Contracts;
using _01.Logger.Models.Enumerations;

namespace _01.Logger.Models.Appenders
{
    public abstract class Appender : IAppender
    {
        protected int messegesAppend;
         
        protected Appender(ILayout layout , Level level)
        {
            this.Layout = layout;
            this.Level = Level;
        }

        public ILayout Layout { get; }

        public Level Level { get; }

        public abstract void Append(IError error);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString()}, Messages appended: {this.messegesAppend}";
        }
    }
}
