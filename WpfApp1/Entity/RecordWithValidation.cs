using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public abstract record RecordWithValidation
    {
        protected RecordWithValidation()
        {
            Validate();
        }

        protected abstract void Validate();
    }
}
