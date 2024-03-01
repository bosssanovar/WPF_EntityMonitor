namespace Entity
{
    public class XXEntity : EntityBase
    {
        private const string Text_InitValue = "Init Value";
        private const int Number_InitValue = 100;
        private const bool Bool_InitValue = true;
        private const SomeEnum SomeEnum_InitValue = Entity.SomeEnum.Pig;

        private BoolVO _bool = new(Bool_InitValue);

        public TextVO Text { get; set; } = new(Text_InitValue);

        public NumberVO Number { get; set; } = new(Number_InitValue);

        public BoolVO Bool
        {
            get => _bool;
            set
            {
                _bool = value;

                CurrectSomeEnumIfNeed();
            }
        }
        public SomeEnumVO SomeEnum { get; set; } = new SomeEnumVO(SomeEnum_InitValue);

        public void Init()
        {
            Text = new TextVO(Text_InitValue);
            Number = new NumberVO(Number_InitValue);
            Bool = new BoolVO(Bool_InitValue);
            SomeEnum = new SomeEnumVO(SomeEnum_InitValue);
        }

        public XXEntity Clone()
        {
            return (XXEntity)MemberwiseClone();
        }

        private void CurrectSomeEnumIfNeed()
        {
            if (!Bool.Content && SomeEnum.Content == Entity.SomeEnum.Cat)
            {
                SomeEnum = new SomeEnumVO(SomeEnum_InitValue);
            }
        }
    }
}
