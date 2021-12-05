using System.Collections.Generic;
using System.Linq;

namespace D4_GiantSquid
{
    public class LeaderBoard
    {
        private readonly List<Winner> _winners = new List<Winner>();

        public void AddWinner(Winner winner)
        {
            _winners.Add(winner);
        }

        public Winner First => _winners.FirstOrDefault();
        public Winner Last => _winners.LastOrDefault();
    }
}