using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class TopicMappingBase:EntityBase, IEquatable<TopicMappingBase>
	{
			
		public System.Int32 TopicId{ get; set; }

		public System.Int32 ParentTopicId{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<TopicMappingBase> Members

        public virtual bool Equals(TopicMappingBase other)
        {
			if(this.TopicId==other.TopicId  && this.ParentTopicId==other.ParentTopicId  && this.CreatedOn==other.CreatedOn )
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
