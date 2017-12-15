using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class LocaleSettingBase:EntityBase, IEquatable<LocaleSettingBase>
	{
			
		[PrimaryKey]
		public System.Int32 LocaleSettingId{ get; set; }

		public System.Guid LocaleSettingGuid{ get; set; }

		public System.String Name{ get; set; }

		public System.String Description{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		public System.Int32 DefaultCurrencyId{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<LocaleSettingBase> Members

        public virtual bool Equals(LocaleSettingBase other)
        {
			if(this.LocaleSettingId==other.LocaleSettingId  && this.LocaleSettingGuid==other.LocaleSettingGuid  && this.Name==other.Name  && this.Description==other.Description  && this.DisplayOrder==other.DisplayOrder  && this.CreatedOn==other.CreatedOn  && this.DefaultCurrencyId==other.DefaultCurrencyId )
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
