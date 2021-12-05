namespace D4_GiantSquid
{
    public class BingoNumber
    {
        public BingoNumber(int value)
        {
            Value = value;
        }

        public bool Marked { get; private set; }

        public int Value { get; private set; }

        public void Mark()
        {
            Marked = true;
        }
    }
}