namespace Entity
{
    public record TextVO(string Content) : ValueObjectBase<string>(Content), IInputLimit<string>
    {
        private const int MaxLength = 10;

        public static string CurrectValue(string value)
        {
            if (!IsValid(value))
            {
                return value.Substring(0, MaxLength);
            }
            return value;
        }

        public static bool IsValid(string value)
        {
            return value.Length <= MaxLength;
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
