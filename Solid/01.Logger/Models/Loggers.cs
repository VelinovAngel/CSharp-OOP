using System.Collections.Generic;
using _01.Logger.Models.Contracts;

namespace _01.Logger.Models
{
    public class Loggers : ILogger
    {
        private readonly ICollection<IAppender> appenders;

        public Loggers(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public Loggers(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders
            => (IReadOnlyCollection<IAppender>)this.appenders;

        public void Log(IError error)
        {
            foreach (IAppender appender in this.appenders)
            {
                if (error.Level >= appender.Level)
                {
                    appender.Append(error);
                }
            }
        }
    }

}
