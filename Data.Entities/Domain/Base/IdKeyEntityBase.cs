using System;

namespace Data.Entities.Domain.Base
{
    public abstract class IdKeyEntityBase<TKey> : IIdentifiable<TKey> where TKey : IComparable, IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }
}
