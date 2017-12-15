using System;
using System.Collections.Generic;

namespace IABazaar.Core.Entities
{
	[Serializable]
    public abstract class EntityBase
    {
        public bool IsUpdated { get; set; }
    }
}