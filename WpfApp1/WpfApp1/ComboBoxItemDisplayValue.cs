using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public record ComboBoxItemDisplayValue<T>(T Value, string Display)
    {
    }
}
