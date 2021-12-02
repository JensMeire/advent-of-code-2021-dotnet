using System;
using System.Collections.Generic;
using System.Linq;

namespace D2_Dive
{
    public class CommandParser
    {
        private readonly IList<string> _data;

        public CommandParser(IList<string> data)
        {
            _data = data;
        }

        public List<PositionCommand> GetCommands()
        {
            return _data.Select(x =>
                {
                    var parts = x.Split(' ');
                    if (parts?.Length != 2) return null;
                    var direction = parts[0].ToLower();
                    var amount = int.Parse(parts[1]);

                    return GetCommand(direction, amount);
                })
                .Where(x => x != null)
                .ToList();
        }

        private static PositionCommand GetCommand(string direction, int amount)
        {
            switch (direction)
            {
                case "forward": return new HorizontalPositionCommand(amount);
                case "down": return new VerticalPositionCommand(amount);
                case "up": return new VerticalPositionCommand(amount * -1);
                default: return new HorizontalPositionCommand(0);
            }
        }
    }
}