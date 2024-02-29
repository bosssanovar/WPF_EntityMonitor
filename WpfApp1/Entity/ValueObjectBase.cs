namespace Entity
{
    public abstract record ValueObjectBase<T>(T Content) : RecordWithValidation
    {
    }
}
