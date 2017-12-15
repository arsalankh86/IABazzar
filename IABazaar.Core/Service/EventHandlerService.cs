using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using IABazaar.Core.Entities;
using IABazaar.Core.DataInterfaces;
using IABazaar.Core.IService;

namespace IABazaar.Core.Service
{
		
	public class EventHandlerService : IEventHandlerService 
	{
		private IEventHandlerRepository _iEventHandlerRepository;
        
		public EventHandlerService(IEventHandlerRepository iEventHandlerRepository)
		{
			this._iEventHandlerRepository = iEventHandlerRepository;
		}
        
        public Dictionary<string, string> GetEventHandlerBasicSearchColumns()
        {
            
            return this._iEventHandlerRepository.GetEventHandlerBasicSearchColumns();
           
        }
        
        public List<SearchColumn> GetEventHandlerAdvanceSearchColumns()
        {
            
            return this._iEventHandlerRepository.GetEventHandlerAdvanceSearchColumns();
           
        }


		public IABazaar.Core.Entities.EventHandler GetEventHandler(System.Int32 EventId)
		{
			return _iEventHandlerRepository.GetEventHandler(EventId);
		}

		public IABazaar.Core.Entities.EventHandler UpdateEventHandler(IABazaar.Core.Entities.EventHandler entity)
		{
			return _iEventHandlerRepository.UpdateEventHandler(entity);
		}

		public bool DeleteEventHandler(System.Int32 EventId)
		{
			return _iEventHandlerRepository.DeleteEventHandler(EventId);
		}

		public List<IABazaar.Core.Entities.EventHandler> GetAllEventHandler()
		{
			return _iEventHandlerRepository.GetAllEventHandler();
		}

		public IABazaar.Core.Entities.EventHandler InsertEventHandler(IABazaar.Core.Entities.EventHandler entity)
		{
			 return _iEventHandlerRepository.InsertEventHandler(entity);
		}


	}
	
	
}
