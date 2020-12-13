using System.Linq;
using System.Collections.Generic;

using SantaWorkshop.Repositories.Contracts;
using SantaWorkshop.Models.Dwarfs.Contracts;

namespace SantaWorkshop.Repositories
{
    public class DwarfRepository : IRepository<IDwarf>
    {
        private readonly ICollection<IDwarf> models;

        public DwarfRepository()
        {
            this.models = new List<IDwarf>();
        }

        public IReadOnlyCollection<IDwarf> Models
            => (IReadOnlyCollection<IDwarf>)this.models;

        public void Add(IDwarf model)
        {
            this.models.Add(model);
        }

        public bool Remove(IDwarf model)
        {
            return this.models.Remove(model);
        }

        public IDwarf FindByName(string name)
        {
            var dwarf = models.FirstOrDefault(c => c.Name == name);

            return dwarf;
        }
    }
}
