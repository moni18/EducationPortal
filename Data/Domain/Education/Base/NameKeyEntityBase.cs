﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain.Education.Base
{
    public abstract class NameKeyEntityBase<TKey> : IdKeyEntityBase<TKey> where TKey:IComparable, IEquatable<TKey>
    {
        public string Name { get; set; }
    }
}
