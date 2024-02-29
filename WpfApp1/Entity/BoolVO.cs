using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public record BoolVO(bool Content) : ValueObjectBase<bool>(Content), IInputLimit<bool>
    {
        public static bool CurrectValue(bool value)
        {
            return value;
        }

        public static bool IsValid(bool value)
        {
            return true;
        }

        protected override void Validate()
        {
            // None.
        }
    }
}
