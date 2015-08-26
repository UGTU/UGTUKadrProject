using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Kadr.Data.Common
{
    public class AdvancedBindingList<T> : BindingList<T>
    {
        protected override void RemoveItem(int itemIndex)
        {
            //itemIndex = index of item which is going to be removed
            //get item from binding list at itemIndex position
            T deletedItem = this.Items[itemIndex];

            if (BeforeRemove != null)
            {
                //raise event containing item which is going to be removed
                BeforeRemove(deletedItem);
            }

            //remove item from list
            base.RemoveItem(itemIndex);
        }

        public delegate void myIntDelegate(T deletedItem);
        public event myIntDelegate BeforeRemove;
    }
    
}
