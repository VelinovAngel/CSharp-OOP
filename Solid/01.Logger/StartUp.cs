using System;
using System.Linq;
using System.Collections.Generic;

using _01.Logger.Core;
using _01.Logger.Common;
using _01.Logger.Models;
using _01.Logger.Factories;
using _01.Logger.IOManegment;
using _01.Logger.Models.Files;
using _01.Logger.Core.Contracts;
using _01.Logger.Models.Contracts;
using _01.Logger.Models.Enumerations;
using _01.Logger.Models.PathManagment;
using _01.Logger.IOManegment.Contracts;

namespace _01.Logger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory();
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            int n = int.Parse(reader.ReadLine());

            IPathManager pathManager = new PathManager("logs", "logs.txt");
            IFile file = new LogFile(pathManager);

            ILogger logger = SetUpLogger(n, writer, reader, file,layoutFactory,appenderFactory);

            IEngine engine = new Engine(logger, reader, writer);
            engine.Run();
        }

        private static ILogger SetUpLogger(int appenderCount, IWriter writer, IReader reader, IFile file, LayoutFactory layoutFactory, AppenderFactory appenderFactory)
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

                Level level = ParseLevel(appernderArg, writer, ref hasError);

                if (hasError)
                {
                    continue;
                }
                try
                {
                    ILayout layout = layoutFactory.CreateLayout(layoutType);
                    IAppender appender = appenderFactory.CreateAppender(appenderType, layout, level, file);

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

        private static Level ParseLevel(string[] levelStr, IWriter writer, ref bool hasError)
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
