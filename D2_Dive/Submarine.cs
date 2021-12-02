using System.Collections.Generic;

namespace D2_Dive
{
    public class Submarine
    {

        private int _verticalPosition;
        private int _horizontalPosition;

        public void Move(IList<PositionCommand> commands)
        {
            foreach (var positionCommand in commands)
            {
                Move(positionCommand);
            }
        }

        public void Move(PositionCommand command)
        {
            if (command is HorizontalPositionCommand)
                _horizontalPosition += command.Amount;
            else _verticalPosition += command.Amount;
        }
        

        public int VerticalPosition => _verticalPosition;
        public int HorizontalPosition => _horizontalPosition;
    }
}