using System;
using System.Linq;
using System.Globalization;

using _01.Logger.Common;
using _01.Logger.Models.Errors;
using _01.Logger.Core.Contracts;
using _01.Logger.Models.Contracts;
using _01.Logger.Models.Enumerations;
using _01.Logger.IOManegment.Contracts;

namespace _01.Logger.Core
{
    public class Engine : IEngine
    {
        private readonly ILogger logger;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(ILogger logger, IReader reader , IWriter writer)
        {
            this.logger = logger;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command = string.Empty;
            while ((command = this.reader.ReadLine()) != "END")
            {
                string[] errors = command
                    .Split('|')
                    .ToArray();

                string levelSrt = errors[0];
                string dateTimeStr = errors[1];
                string messege = errors[2];

                bool isLevelValid = Enum.TryParse(typeof(Level), levelSrt, true, out object levelObj);

                if (!isLevelValid)
                {
                    writer.WriteLine(GlobalConstans.InvalidLevelType);
                    continue;
                }

                Level level = (Level)levelObj;

                bool isDateTimeValid = DateTime.TryParseExact(dateTimeStr, GlobalConstans.DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime);

                if (!isDateTimeValid)
                {
                    this.writer.WriteLine(GlobalConstans.InvalidDateTimeFormat);
                }

                IError error = new Error(dateTime, messege, level);

                this.logger.Log(error);
            }

            writer.WriteLine(this.logger.ToString());
        }
    }
}
