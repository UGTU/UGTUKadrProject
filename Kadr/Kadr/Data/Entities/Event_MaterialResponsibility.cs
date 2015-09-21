using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Controllers;

namespace Kadr.Data
{
    public partial class Event_MaterialResponsibility
    {
        public Event_MaterialResponsibility(UIX.Commands.ICommandManager commandManager, FactStaff fsStaff)
            : this()
        {
            commandManager.Execute(new UIX.Commands.GenericPropertyCommand<Event_MaterialResponsibility, Event>(this, "Event",
                new Event(commandManager, fsStaff.CurrentChange, MagicNumberController.MatResponsibilityKind, true, null,null), null), this);
            commandManager.Execute(
                            new UIX.Commands.GenericPropertyCommand<Event, EventType>(this.Event, "EventType",
                               MagicNumberController.BeginEventType, null), this);
         /*   commandManager.Execute(
                            new UIX.Commands.GenericPropertyCommand<Event, Prikaz>(this.Event, "Prikaz",
                               new Prikaz(), null), this);*/

        }
    }
}
