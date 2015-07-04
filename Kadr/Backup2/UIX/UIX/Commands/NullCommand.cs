using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UIX.Commands
{
    [System.ComponentModel.DisplayName("Пустая команда")]
    public class NullCommand:ICommand
    {
        private NullCommand() { }

        public static NullCommand Empty
        {
            get
            {
                return new NullCommand();
            }
        }

        #region ICommand Members

        public void Execute(object sender)
        {
            
        }

        public void Unexecute(object sender)
        {
            
        }

        public bool IsOneWayCommand(object sender)
        {
            return false;
        }

        #endregion
    }
}
