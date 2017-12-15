using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IABazaar.Core.Entities
{
	[Serializable]	
	public abstract partial class TopicBase:EntityBase, IEquatable<TopicBase>
	{
			
		[PrimaryKey]
		public System.Int32 TopicId{ get; set; }

		public System.Guid TopicGuid{ get; set; }

		public System.String Name{ get; set; }

		public System.String Title{ get; set; }

		public System.String Description{ get; set; }

		public System.String SeTitle{ get; set; }

		public System.String SeDescription{ get; set; }

		public System.String SeKeywords{ get; set; }

		public System.String SeNoScript{ get; set; }

		public System.String Password{ get; set; }

		public System.Byte? RequiresSubscription{ get; set; }

		public System.Byte? RequiresDisclaimer{ get; set; }

		public System.String XmlPackage{ get; set; }

		public System.String ExtensionData{ get; set; }

		public System.Byte ShowInSiteMap{ get; set; }

		public System.Int32 SkinId{ get; set; }

		public System.String ContentsBgColor{ get; set; }

		public System.String PageBgColor{ get; set; }

		public System.String GraphicsColor{ get; set; }

		public System.Byte HtmlOk{ get; set; }

		public System.Byte Deleted{ get; set; }

		public System.Int32 StoreId{ get; set; }

		public System.Int32 DisplayOrder{ get; set; }

		public System.DateTime CreatedOn{ get; set; }

		
		public virtual bool IsTransient()
        {

            return EntityHelper.IsTransient(this);
        }
		
		#region IEquatable<TopicBase> Members

        public virtual bool Equals(TopicBase other)
        {
			if(this.TopicId==other.TopicId  && this.TopicGuid==other.TopicGuid  && this.Name==other.Name  && this.Title==other.Title  && this.Description==other.Description  && this.SeTitle==other.SeTitle  && this.SeDescription==other.SeDescription  && this.SeKeywords==other.SeKeywords  && this.SeNoScript==other.SeNoScript  && this.Password==other.Password  && this.RequiresSubscription==other.RequiresSubscription  && this.RequiresDisclaimer==other.RequiresDisclaimer  && this.XmlPackage==other.XmlPackage  && this.ExtensionData==other.ExtensionData  && this.ShowInSiteMap==other.ShowInSiteMap  && this.SkinId==other.SkinId  && this.ContentsBgColor==other.ContentsBgColor  && this.PageBgColor==other.PageBgColor  && this.GraphicsColor==other.GraphicsColor  && this.HtmlOk==other.HtmlOk  && this.Deleted==other.Deleted  && this.StoreId==other.StoreId  && this.DisplayOrder==other.DisplayOrder  && this.CreatedOn==other.CreatedOn )
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
