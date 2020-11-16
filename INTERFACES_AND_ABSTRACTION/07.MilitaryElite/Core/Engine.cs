﻿using System;
using System.Linq;
using System.Collections.Generic;

using _07.MilitaryElite.Factory;
using _07.MilitaryElite.Contracts;
using _07.MilitaryElite.IO.Contracts;
using _07.MilitaryElite.Core.Contracts;
using _07.MilitaryElite.Exceptions;

namespace _07.MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private readonly FacotrySoldiers facotry;

        //private ICollection<ISoldier> soldiers;

        //private Engine()
        //{
        //    soldiers = new List<ISoldier>();
        //}

        public Engine(IReader reader, IWriter writer)
            //: this()
        {
            this.reader = reader;
            this.writer = writer;
            this.facotry = new FacotrySoldiers();
        }

        public void Run()
        {
            string command = string.Empty;
            while ((command = this.reader.ReadLine()) != "End")
            {

                string[] cmdArg = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string soldierType = cmdArg[0];
                int id = int.Parse(cmdArg[1]);
                string firstName = cmdArg[2];
                string lastName = cmdArg[3];
                string[] remainingAgm = cmdArg
                    .Skip(4)
                    .ToArray();

                ISoldier soldier = null;

                try
                {
                    soldier = facotry.CreateSoldier(soldierType, id, firstName, lastName, remainingAgm);
                }
                catch (InvalidCorpException ice)
                {
                    continue;
                }


            }

            foreach (var soldier in facotry.soldiers)
            {
                Console.WriteLine(soldier);
            }

        }
    }
}
