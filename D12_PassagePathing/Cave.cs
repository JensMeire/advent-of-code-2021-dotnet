using System.Collections.Generic;
using System.Linq;

namespace D12_PassagePathing
{
    public class Cave
    {
        public readonly string Id;
        public List<Cave> Caves = new List<Cave>();

        public Cave(string id)
        {
            Id = id;
        }
        
        public void AddConnection(Cave cave)
        {
            if(Caves.All(x => x.Id != cave.Id))
                Caves.Add(cave);
        }

        public bool IsBig => char.IsUpper(Id.First());

        public override string ToString()
        {
            return Id;
        }
    }
}