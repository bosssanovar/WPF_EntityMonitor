namespace Entity
{
    public record NumberVO(int Content) : ValueObjectBase<int>(Content), IInputLimit<int>
    {
        private const int MinValue = 0;
        private const int MaxValue = 500;

        public static int CurrectValue(int value)
        {
            if (value < MinValue)
            {
                return MinValue;
            }
            else if (value > MaxValue)
            {
                return MaxValue;
            }
            return value;
        }

        public static bool IsValid(int value)
        {
            if (value < MinValue)
            {
                return false;
            }
            else if (value > MaxValue)
            {
                return false;
            }
            return true;
        }

        protected override void Validate()
        {
            if (!IsValid(Content))
            {
                throw new ArgumentException("Invalid Value", nameof(Content));
            }
        }
    }
}
