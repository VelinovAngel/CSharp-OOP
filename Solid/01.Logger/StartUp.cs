using System;
using System.Linq;
using System.Collections.Generic;

using _01.Logger.Common;
using _01.Logger.Models;
using _01.Logger.Factories;
using _01.Logger.IOManegment;
using _01.Logger.Models.Files;
using _01.Logger.Models.Contracts;
using _01.Logger.Models.Enumerations;
using _01.Logger.Models.PathManagment;
using _01.Logger.IOManegment.Contracts;

namespace _01.Logger
{
    public class StartUp
    {
        private readonly LayoutFactory layoutFactory =  new LayoutFactory();
        private readonly AppenderFactory appenderFactory = new AppenderFactory();



        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IPathManager pathManager = new PathManager("logs", "logs.txt");
            IFile file = new LogFile(pathManager);

            int n = int.Parse(reader.ReadLine());

            ILogger logger = new Loggers(appenders);

        }

        private ILogger SetUpLogger(int appenderCount, IWriter writer, IReader reader , IFile file)
        {
            ICollection<IAppender> appenders = new HashSet<IAppender>();

            for (int i = 0; i < appenderCount; i++)
            {
                string[] appernderArg = reader.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string appenderType = appernderArg[0];
                string layoutType = appernderArg[1];

                bool hasError = false;

                Level level = this.ParseLevel(appernderArg, writer, ref hasError);

                if (hasError)
                {
                    continue;
                }
                try
                {
                    ILayout layout = this.layoutFactory.CreateLayout(layoutType);
                    IAppender appender = this.appenderFactory.CreateAppender(appenderType, layout, level , file);

                    appenders.Add(appender);
                }
                catch (InvalidOperationException ioe)
                {
                    writer.WriteLine(ioe.Message);
                    continue;
                }
            }

            ILogger logger = new Loggers(appenders);

            return logger;
        }

        private Level ParseLevel(string[] levelStr, IWriter writer, ref bool hasError)
        {
            Level appenderLevel = Level.INFO;

            if (levelStr.Length == 3)
            {
                bool isEnumValid = Enum.TryParse(typeof(Level), levelStr[2], true, out object enumParsed);

                if (!isEnumValid)
                {
                    writer.WriteLine(GlobalConstans.InvalidLevelType);
                    hasError = true;
                }

                appenderLevel = (Level)enumParsed;
            }

            return appenderLevel;
        }
    }
}
