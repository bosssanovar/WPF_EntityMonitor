using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public record SomeEnumVO(SomeEnum Content) : ValueObjectBase<SomeEnum>(Content), IInputLimit<SomeEnum>
    {
        public static SomeEnum CurrectValue(SomeEnum value)
        {
            return value;
        }

        public static bool IsValid(SomeEnum value)
        {
            return true;
        }

        protected override void Validate()
        {
            // None.
        }
    }
}
