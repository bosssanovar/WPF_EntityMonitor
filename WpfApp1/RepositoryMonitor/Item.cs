using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMonitor
{
    public record Item(string Path, string OldValue, string NewValue)
    {
    }
}
