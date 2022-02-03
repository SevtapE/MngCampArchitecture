using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Paging
{
    public class BasePageableModel
    {

        int From { get; }
        int Index { get; }
        int Size { get; }
        int Count { get; }
        int Pages { get; }
        bool HasPrevious { get; }
        bool HasNext { get; }

    }
}
