using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.Education.Base
{
    public interface IIdentifiable<TKey> where TKey: IComparable, IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}
