using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class DocumentAffiliateBase:EntityBase, IEquatable<DocumentAffiliateBase>
	{
			
		public System.Int32 DocumentId{ get; set; }

		public System.Int32 AffiliateId{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<DocumentAffiliateBase> Members

        public virtual bool Equals(DocumentAffiliateBase other)
        {
			if(this.DocumentId==other.DocumentId  && this.AffiliateId==other.AffiliateId  && this.CreatedOn==other.CreatedOn )
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
