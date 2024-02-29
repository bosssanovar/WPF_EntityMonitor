namespace Entity
{
    public abstract class EntityBase
    {
        Guid Identifier { get; }

        public EntityBase()
        {
            Identifier = Guid.NewGuid();
        }

        public bool IsSameAs(EntityBase other)
        {
            return Identifier == other.Identifier;
        }
    }
}
