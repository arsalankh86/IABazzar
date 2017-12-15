
using System;
using System.ComponentModel;
using System.Collections;


namespace IABazaar.Core.Entities
{
	[Serializable]		
	public partial class Product : ProductBase 
	{



        public bool InStock { get; set; }
    }
	
	
}
