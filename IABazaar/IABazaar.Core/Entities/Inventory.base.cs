using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class InventoryBase:EntityBase, IEquatable<InventoryBase>
	{
			
		[PrimaryKey]
		public System.Int32 InventoryId{ get; set; }

		public System.Guid InventoryGuid{ get; set; }

		public System.Int32 VariantId{ get; set; }

		public System.String Color{ get; set; }

		public System.String Size{ get; set; }

		public System.Int32 Quan{ get; set; }

		public System.String VendorFullSku{ get; set; }

		public System.String WarehouseLocation{ get; set; }

		public System.Decimal WeightDelta{ get; set; }

		public System.String VendorId{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<InventoryBase> Members

        public virtual bool Equals(InventoryBase other)
        {
			if(this.InventoryId==other.InventoryId  && this.InventoryGuid==other.InventoryGuid  && this.VariantId==other.VariantId  && this.Color==other.Color  && this.Size==other.Size  && this.Quan==other.Quan  && this.VendorFullSku==other.VendorFullSku  && this.WarehouseLocation==other.WarehouseLocation  && this.WeightDelta==other.WeightDelta  && this.VendorId==other.VendorId  && this.ExtensionData==other.ExtensionData  && this.CreatedOn==other.CreatedOn )
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
