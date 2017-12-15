using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;

namespace IABazaar.Core.IService
{
		
	public interface IEventHandlerService
	{
        Dictionary<string, string> GetEventHandlerBasicSearchColumns();
        
        List<SearchColumn> GetEventHandlerAdvanceSearchColumns();

		IABazaar.Core.Entities.EventHandler GetEventHandler(System.Int32 EventId);
		IABazaar.Core.Entities.EventHandler UpdateEventHandler(IABazaar.Core.Entities.EventHandler entity);
		bool DeleteEventHandler(System.Int32 EventId);
		List<IABazaar.Core.Entities.EventHandler> GetAllEventHandler();
		IABazaar.Core.Entities.EventHandler InsertEventHandler(IABazaar.Core.Entities.EventHandler entity);

	}
	
	
}
