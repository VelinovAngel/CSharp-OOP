using System.Linq;
using System.Collections.Generic;

using SantaWorkshop.Repositories.Contracts;
using SantaWorkshop.Models.Presents.Contracts;

namespace SantaWorkshop.Repositories
{
    public class PresentRepository : IRepository<IPresent>
    {
        private readonly ICollection<IPresent> models;

        public PresentRepository()
        {
            this.models = new List<IPresent>();
        }


        public IReadOnlyCollection<IPresent> Models
            => (IReadOnlyCollection<IPresent>)this.models;

        public void Add(IPresent model)
        {
            this.models.Add(model);
        }

        public bool Remove(IPresent model)
        {
            return this.models.Remove(model);
        }

        public IPresent FindByName(string name)
        {
            var present = this.models.FirstOrDefault(pr => pr.Name == name);

            return present;
        }

    }
}
