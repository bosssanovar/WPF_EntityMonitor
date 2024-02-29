namespace Entity
{
    internal interface IInputLimit<T>
    {
        static abstract bool IsValid(T value);

        static abstract T CurrectValue(T value);
    }
}
