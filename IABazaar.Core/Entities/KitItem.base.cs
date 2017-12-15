using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class KitItemBase:EntityBase, IEquatable<KitItemBase>
	{
			
		[PrimaryKey]
		public System.Int32 KitItemId{ get; set; }

		public System.Guid KitItemGuid{ get; set; }

		public System.Int32 KitGroupId{ get; set; }

		public System.String Name{ get; set; }

		public System.String Description{ get; set; }

		public System.Decimal PriceDelta{ get; set; }

		public System.Decimal WeightDelta{ get; set; }

		public System.Byte IsDefault{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.Int32? TextOptionMaxLength{ get; set; }

		public System.Int32? TextOptionWidth{ get; set; }

		public System.Int32? TextOptionHeight{ get; set; }

		public System.Int32? InventoryVariantId{ get; set; }

		public System.Int32 InventoryQuantityDelta{ get; set; }

		public System.String InventoryVariantColor{ get; set; }

		public System.String InventoryVariantSize{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<KitItemBase> Members

        public virtual bool Equals(KitItemBase other)
        {
			if(this.KitItemId==other.KitItemId  && this.KitItemGuid==other.KitItemGuid  && this.KitGroupId==other.KitGroupId  && this.Name==other.Name  && this.Description==other.Description  && this.PriceDelta==other.PriceDelta  && this.WeightDelta==other.WeightDelta  && this.IsDefault==other.IsDefault  && this.DisplayOrder==other.DisplayOrder  && this.ExtensionData==other.ExtensionData  && this.TextOptionMaxLength==other.TextOptionMaxLength  && this.TextOptionWidth==other.TextOptionWidth  && this.TextOptionHeight==other.TextOptionHeight  && this.InventoryVariantId==other.InventoryVariantId  && this.InventoryQuantityDelta==other.InventoryQuantityDelta  && this.InventoryVariantColor==other.InventoryVariantColor  && this.InventoryVariantSize==other.InventoryVariantSize  && this.CreatedOn==other.CreatedOn )
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
