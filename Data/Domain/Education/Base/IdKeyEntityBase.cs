using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.Education.Base
{
    public abstract class IdKeyEntityBase<TKey> : IIdentifiable<TKey> where TKey : IComparable, IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }
}
