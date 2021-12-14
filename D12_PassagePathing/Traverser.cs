using System.Collections.Generic;
using System.Linq;

namespace D12_PassagePathing
{
    public class Traverser
    {
        private readonly Dictionary<string, Cave> _caves;

        public Traverser(Dictionary<string, Cave> caves)
        {
            _caves = caves;
        }

        private Cave GetStartCave => _caves["start"];
        public readonly List<List<Cave>> Paths = new List<List<Cave>>();

        public void Traverse(int amountOfSmallCaves = 1)
        {
            var start = GetStartCave;
            Recur(start, new List<Cave>(), amountOfSmallCaves);
        }

        public void Recur(Cave cave, List<Cave> paths, int amountOfSmallCaves)
        {
            var p = new List<Cave>(paths);
            p.Add(cave);
            if (cave.Id == "end")
            {
                Paths.Add(p);
                return;
            }
            
            foreach (var subCave in cave.Caves)
            {
                
                if(subCave.Id == "start")
                    continue;
                
                if (!subCave.IsBig && paths.Any(x => x.Id == subCave.Id)){
                    if(amountOfSmallCaves > 1) Recur(subCave, p, amountOfSmallCaves - 1);
                    continue;
                }

                Recur(subCave, p, amountOfSmallCaves);
            }
        }
    }
}