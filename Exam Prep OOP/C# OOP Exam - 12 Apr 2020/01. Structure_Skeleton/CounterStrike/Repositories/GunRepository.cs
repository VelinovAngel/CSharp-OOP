﻿using System;
using System.Collections.Generic;
using System.Linq;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly ICollection<IGun> models;

        public GunRepository()
        {
            this.models = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models
            => (IReadOnlyCollection<IGun>)this.models;


        public void Add(IGun model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }

            models.Add(model);
        }

        public bool Remove(IGun model)
        {
            return models.Remove(model);
        }

        public IGun FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }
    }
}
