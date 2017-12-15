using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class OrderNumbersBase:EntityBase, IEquatable<OrderNumbersBase>
	{
			
		[PrimaryKey]
		public System.Int32 OrderNumber{ get; set; }

		public System.Guid OrderNumberGuid{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<OrderNumbersBase> Members

        public virtual bool Equals(OrderNumbersBase other)
        {
			if(this.OrderNumber==other.OrderNumber  && this.OrderNumberGuid==other.OrderNumberGuid  && this.CreatedOn==other.CreatedOn )
			{
				return true;
			}
			else
			{
				return false;
			}
		
		}

        #endregion
		
		
		
	}
	
	
}
