using System;

namespace Data.Domain.Hospital.Base
{
    public abstract class NameKeyEntityBase<TKey> : IdKeyEntityBase<TKey> where TKey : IComparable, IEquatable<TKey>
    {
        public string Name { get; set; }
    }
}
