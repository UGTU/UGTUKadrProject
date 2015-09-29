using Kadr.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    public partial class Event_BusinessTrip
    {
        public Event_BusinessTrip(UIX.Commands.ICommandManager commandManager, FactStaffHistory fsh, EventType eType, BusinessTrip trip = null, Prikaz prEnd = null, DateTime? endTime = null)
            : this()
        {
            
            commandManager.Execute(new UIX.Commands.GenericPropertyCommand<Event_BusinessTrip, Event>(this, "Event",
                new Event(commandManager, fsh, MagicNumberController.BusinessTripKind, eType, false, null, endTime), null), this);

            if (trip != null) commandManager.Execute(new UIX.Commands.GenericPropertyCommand<Event_BusinessTrip, BusinessTrip>(this, "BusinessTrip", trip, null), this);

            if (prEnd == null) return;
            commandManager.Execute(new UIX.Commands.GenericPropertyCommand<Event, Prikaz>(this.Event, "PrikazEnd",prEnd, null), this);
            commandManager.Execute(new UIX.Commands.GenericPropertyCommand<Event, DateTime?>(this.Event, "DateEnd", endTime, null), this);
        }
    }
}
