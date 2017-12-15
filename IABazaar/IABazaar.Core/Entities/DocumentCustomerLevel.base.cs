using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class DocumentCustomerLevelBase:EntityBase, IEquatable<DocumentCustomerLevelBase>
	{
			
		public System.Int32 DocumentId{ get; set; }

		public System.Int32 CustomerLevelId{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<DocumentCustomerLevelBase> Members

        public virtual bool Equals(DocumentCustomerLevelBase other)
        {
			if(this.DocumentId==other.DocumentId  && this.CustomerLevelId==other.CustomerLevelId  && this.CreatedOn==other.CreatedOn )
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
