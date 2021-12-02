using System.Collections.Generic;

namespace D2_Dive
{
    public class CoolSubmarine
    {
        private int _verticalPosition;
        private int _horizontalPosition;
        private int _aim;

        public void Move(IList<PositionCommand> commands)
        {
            foreach (var positionCommand in commands)
            {
                Move(positionCommand);
            }
        }

        public void Move(PositionCommand command)
        {
            if (command is VerticalPositionCommand)
            {
                _aim += command.Amount;
                return;
            }

            _horizontalPosition += command.Amount;
            _verticalPosition += (command.Amount * _aim);
        }
        

        public int VerticalPosition => _verticalPosition;
        public int HorizontalPosition => _horizontalPosition; 
    }
}