using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    public partial class Event_MaterialResponsibility
    {
        public Event_MaterialResponsibility(UIX.Commands.ICommandManager commandManager, FactStaff fsStaff)
            : this()
        {
            commandManager.Execute(new UIX.Commands.GenericPropertyCommand<Event_MaterialResponsibility, Event>(this, "Event", 
                new Event(), null), this);
            commandManager.Execute(new UIX.Commands.GenericPropertyCommand<Event, Prikaz>(this.Event, "Prikaz", new Prikaz(), null), this);

        }
    }
}
