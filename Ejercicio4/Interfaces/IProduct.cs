using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4.Interfaces
{
    public interface IProduct
    {
        string DealName { get; }
        string LocalId { get; }
        int Titles { get; }
        DateTime AvailableSince { get; }
    }
}
