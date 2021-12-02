namespace D2_Dive
{
    public abstract class PositionCommand
    {
        public readonly int Amount;

        protected PositionCommand(int amount)
        {
            Amount = amount;
        }
    }
}