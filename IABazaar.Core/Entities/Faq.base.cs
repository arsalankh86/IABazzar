using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class FaqBase:EntityBase, IEquatable<FaqBase>
	{
			
		[PrimaryKey]
		public System.Int32 Faqid{ get; set; }

		public System.Guid Faqguid{ get; set; }

		public System.String Qtext{ get; set; }

		public System.String Atext{ get; set; }

		public System.Byte Published{ get; set; }

		public System.Byte Wholesale{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.Byte Deleted{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<FaqBase> Members

        public virtual bool Equals(FaqBase other)
        {
			if(this.Faqid==other.Faqid  && this.Faqguid==other.Faqguid  && this.Qtext==other.Qtext  && this.Atext==other.Atext  && this.Published==other.Published  && this.Wholesale==other.Wholesale  && this.ExtensionData==other.ExtensionData  && this.Deleted==other.Deleted  && this.CreatedOn==other.CreatedOn )
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
