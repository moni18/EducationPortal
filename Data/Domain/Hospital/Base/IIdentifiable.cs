using System;

namespace Data.Domain.Hospital.Base
{
    public interface IIdentifiable<TKey> where TKey : IComparable, IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}
